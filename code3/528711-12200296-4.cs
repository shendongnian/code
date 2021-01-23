    List<string> files = new List<string>()
    {
        "c:\\Form1.cs",
        "c:\\Form2.cs",
    };
    
    foreach (string file in files)
    {
        string tempFile = Path.GetFullPath(file) + ".tmp";
    
        using (StreamReader reader = new StreamReader(file))
        {
            using (StreamWriter writer = new StreamWriter(tempFile))
            {
                writer.WriteLine(@"// <copyright file=" + Path.GetFileNameWithoutExtension(file) + @" company=My Company Name>
    // Copyright (c) 2012 All Rights Reserved
    // </copyright>
    // <author>Leniel Macaferi</author>
    // <date> " + DateTime.Now + @"</date>
    // <summary>Class representing a Sample entity</summary>
    ");
    
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }
            }
        }
        File.Delete(file);
        File.Move(tempFile, file);
    }
