    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;
    using System.Text;
    using System.Globalization;
    using System.Diagnostics;
    using System.Data;
    using System.Windows;
    using System.Windows.Controls;
    using System.IO;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using OfficeOpenXml.Drawing.Chart;
    using System.Xml;
    
    public class ProjectLoad {
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="filePath"></param>
            public void Load ( string filePath ) {
    
                // Get the file we are going to process
                FileInfo existingFile = new FileInfo( filePath );
    
                try {
                    if ( existingFile.Exists == true ) {
                        // Open and read the XlSX file.
                        using ( ExcelPackage package = new ExcelPackage( existingFile ) ) {
                            // Get the work book in the file
                            ExcelWorkbook workBook = package.Workbook;
                            if ( workBook != null ) {
                                if ( workBook.Worksheets.Count > 0 ) {
    
                                    // read some data
                                    int sheet_number = 0;
                                    DataTable table = load_sheet_toDataGrid( workBook.Worksheets[sheet_number] );
                                }
                            }
                } catch ( System.IO.IOException ) {
                    //error message
                }
    
            }
    
            /// <summary>
            /// loads the content of a sheet into a datatable
            /// </summary>
            /// <param name="currentWorksheet"></param>
            /// <returns></returns>
            private DataTable load_sheet_toDataGrid ( ExcelWorksheet currentWorksheet ) {
                DataTable dt = new DataTable( );
    
                int rows = currentWorksheet.Dimension.End.Row;
                int cols = currentWorksheet.Dimension.End.Column;
    
                //Add columns
                for ( int c = 0 ; c < cols ; c++ ) {
                    dt.Columns.Add( currentWorksheet.Cells[0 + 1 , c + 1].Value.ToString( ) );
                }
    
                //add values
                for ( int r = 1 ; r < rows ; r++ ) {
                    object[] ob = new object[cols];
                    for ( int c = 0 ; c < cols ; c++ ) {
    
                        double value;
                        bool isDouble = Double.TryParse( currentWorksheet.Cells[r + 1 , c + 1].Value.ToString( ) , out value );
    
                        bool isDate = false;
                        DateTime date = new DateTime( );
                        if ( c == 0 && !isDouble ) {
                            isDate = DateTime.TryParse( currentWorksheet.Cells[r + 1 , c + 1].Value.ToString( ) , out date );
                        }
    
                        if ( isDouble ) {
                            ob[c] = value;
                        } else if ( isDate ) {
                            ob[c] = date;
                        } else {
                            ob[c] = currentWorksheet.Cells[r + 1 , c + 1].Value;
                        }
                    }
                    dt.Rows.Add( ob );
                }
    
                return dt;  
           }
    }
