    namespace NFC.Portability
    {
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.IO;
        using System.Linq;
        using System.Text;
    
        /// <summary>
        /// Loads and reads a file with comma-separated values into a tabular format.
        /// </summary>
        /// <remarks>
        /// Parsing assumes that the first line will always contain headers and that values will be double-quoted to escape double quotes and commas.
        /// </remarks>
        public unsafe class CsvReader
        {
            private const char SEGMENT_DELIMITER = ',';
            private const char DOUBLE_QUOTE = '"';
            private const char CARRIAGE_RETURN = '\r';
            private const char NEW_LINE = '\n';
    
            private DataTable _table = new DataTable();
    
            /// <summary>
            /// Gets the data contained by the instance in a tabular format.
            /// </summary>
            public DataTable Table
            {
                get
                {
                    // validation logic could be added here to ensure that the object isn't in an invalid state
                    
                    return _table;
                }
            }
    
            /// <summary>
            /// Creates a new instance of <c>CsvReader</c>.
            /// </summary>
            /// <param name="path">The fully-qualified path to the file from which the instance will be populated.</param>
            public CsvReader( string path )
            {
                if( path == null )
                {
                    throw new ArgumentNullException( "path" );
                }
                
                FileStream fs = new FileStream( path, FileMode.Open );
                Read( fs );
            }
    
            /// <summary>
            /// Creates a new instance of <c>CsvReader</c>.
            /// </summary>
            /// <param name="stream">The stream from which the instance will be populated.</param>
            public CsvReader( Stream stream )
            {
                if( stream == null )
                {
                    throw new ArgumentNullException( "stream" );
                }
                
                Read( stream );
            }
    
            /// <summary>
            /// Creates a new instance of <c>CsvReader</c>.
            /// </summary>
            /// <param name="bytes">The array of bytes from which the instance will be populated.</param>
            public CsvReader( byte[] bytes )
            {
                if( bytes == null )
                {
                    throw new ArgumentNullException( "bytes" );
                }
                
                MemoryStream ms = new MemoryStream();
                ms.Write( bytes, 0, bytes.Length );
                ms.Position = 0;
    
                Read( ms );
            }
    
            private void Read( Stream s )
            {
                string lines;
    
                using( StreamReader sr = new StreamReader( s ) )
                {
                    lines = sr.ReadToEnd();
                }
    
                if( string.IsNullOrWhiteSpace( lines ) )
                {
                    throw new InvalidOperationException( "Data source cannot be empty." );
                }
    
                bool inQuotes = false;
                int lineNumber = 0;
                StringBuilder buffer = new StringBuilder( 128 );
                List<string> values = new List<string>();
    
                Action endSegment = () =>
                {
                    values.Add( buffer.ToString() );
                    buffer.Clear();
                };
    
                Action endLine = () =>
                {
                    if( lineNumber == 0 )
                    {
                        CreateColumns( values );
                        values.Clear();
                    }
                    else
                    {
                        CreateRow( values );
                        values.Clear();
                    }
    
                    values.Clear();
                    lineNumber++;
                };
    
                fixed( char* pStart = lines )
                {
                    char* pChar = pStart;
                    char* pEnd = pStart + lines.Length;
    
                    while( pChar < pEnd ) // leave null terminator out
                    {
                        if( *pChar == DOUBLE_QUOTE )
                        {
                            if( inQuotes )
                            {
                                if( Peek( pChar, pEnd ) == SEGMENT_DELIMITER )
                                {
                                    endSegment();
                                    pChar++;
                                }
                                else if( !ApproachingNewLine( pChar, pEnd ) )
                                {
                                    buffer.Append( DOUBLE_QUOTE );
                                }
                            }
    
                            inQuotes = !inQuotes;
                        }
                        else if( *pChar == SEGMENT_DELIMITER )
                        {
                            if( !inQuotes )
                            {
                                endSegment();
                            }
                            else
                            {
                                buffer.Append( SEGMENT_DELIMITER );
                            }
                        }
                        else if( AtNewLine( pChar, pEnd ) )
                        {
                            if( !inQuotes )
                            {
                                endSegment();
                                endLine();
                                pChar++;
                            }
                            else
                            {
                                buffer.Append( *pChar );
                            }
                        }
                        else
                        {
                            buffer.Append( *pChar );
                        }
    
                        pChar++;
                    }
                }
    
                // append trailing values at the end of the file
                if( values.Count > 0 )
                {
                    endSegment();
                    endLine();
                }
            }
    
            /// <summary>
            /// Returns the next character in the sequence but does not advance the pointer. Checks bounds.
            /// </summary>
            /// <param name="pChar">Pointer to current character.</param>
            /// <param name="pEnd">End of range to check.</param>
            /// <returns>
            /// Returns the next character in the sequence, or char.MinValue if range is exceeded.
            /// </returns>
            private char Peek( char* pChar, char* pEnd )
            {
                if( pChar < pEnd )
                {
                    return *( pChar + 1 );
                }
    
                return char.MinValue;
            }
    
            /// <summary>
            /// Determines if the current character represents a newline. This includes lookahead for two character newline delimiters.
            /// </summary>
            /// <param name="pChar"></param>
            /// <param name="pEnd"></param>
            /// <returns></returns>
            private bool AtNewLine( char* pChar, char* pEnd )
            {
                if( *pChar == NEW_LINE )
                {
                    return true;
                }
    
                if( *pChar == CARRIAGE_RETURN && Peek( pChar, pEnd ) == NEW_LINE )
                {
                    return true;
                }
    
                return false;
            }
    
            /// <summary>
            /// Determines if the next character represents a newline, or the start of a newline.
            /// </summary>
            /// <param name="pChar"></param>
            /// <param name="pEnd"></param>
            /// <returns></returns>
            private bool ApproachingNewLine( char* pChar, char* pEnd )
            {
                if( Peek( pChar, pEnd ) == CARRIAGE_RETURN || Peek( pChar, pEnd ) == NEW_LINE )
                {
                    // technically this cheats a little to avoid a two char peek by only checking for a carriage return or new line, not both in sequence
                    return true;
                }
    
                return false;
            }
    
            private void CreateColumns( List<string> columns )
            {
                foreach( string column in columns )
                {
                    DataColumn dc = new DataColumn( column );
                    _table.Columns.Add( dc );
                }
            }
    
            private void CreateRow( List<string> values )
            {
                if( values.Where( (o) => !string.IsNullOrWhiteSpace( o ) ).Count() == 0 )
                {
                    return; // ignore rows which have no content
                }
                
                DataRow dr = _table.NewRow();
                _table.Rows.Add( dr );
    
                for( int i = 0; i < values.Count; i++ )
                {
                    dr[i] = values[i];
                }
            }
        }
    }
