    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Replaces text in a file.
    /// </summary>
    /// <param name="filePath">Path of the text file.</param>
    /// <param name="searchText">Text to search for.</param>
    /// <param name="replaceText">Text to replace the search text.</param>
    static public void ReplaceInFile( string filePath, string searchText, string replaceText )
    {
        StreamReader reader = new StreamReader( filePath );
        string content = reader.ReadToEnd();
        reader.Close();
    
        content = Regex.Replace( content, searchText, replaceText );
    
        StreamWriter writer = new StreamWriter( filePath );
        writer.Write( content );
        writer.Close();
    }
