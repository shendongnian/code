    using System;
    using System.IO;
    using SharpCompress.Common;
    using SharpCompress.Reader;
    
    private static String directoryPath = @"C:\Temp";
    
    public static void unTAR(String tarFilePath)
    {
        using (Stream stream = File.OpenRead(tarFilePath))
        {
            var reader = ReaderFactory.Open(stream);
            while (reader.MoveToNextEntry())
            {
                if (!reader.Entry.IsDirectory)
                {
                    reader.WriteEntryToDirectory(directoryPath, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                }
            }
        }
    }
