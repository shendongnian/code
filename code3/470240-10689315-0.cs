        var sourceStream = System.IO.File.OpenRead("myFile.pak");
        var destStream = System.IO.File.Create("modified.pak");
        
        using (var reader = new System.IO.BinaryReader(sourceStream))
        {
            using (var writer = new System.IO.BinaryWriter(destStream))
            {
                while (reader.BaseStream.CanRead)
                {
                    char data = reader.ReadChar();
                    if (data == '?')
                    {
                        writer.Write("<Found!>");
                    }
                    else
                    {
                        writer.Write(data);
                    }
                }
            }
        }
   
