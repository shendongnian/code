    public static class UTF8FileLastLineReader
    {
        // file at path must be utf8 encoded
        public static string ReadLastLineFromUTF8EncodedFile(string path)
        {
            // open read only, we don't want any chance of writing data
            using (System.IO.Stream fs = System.IO.File.OpenRead(path))
            {
                int byteFromFile;
                // start at end of file
                fs.Position = fs.Length;
                // while we have not yet reached start of file, read bytes backwards until '\n' byte is hit
                while (fs.Position > 0)
                {
                    fs.Position--;
                    byteFromFile = fs.ReadByte();
                    if (byteFromFile < 0)
                    {
                        // the only way this should happen is if someone truncates the file out from underneath us while we are reading backwards
                        throw new System.IO.IOException("Error reading from file at " + path);
                    }
                    else if (byteFromFile == '\n')
                    {
                        // we found the new line, break out, fs.Position is one after the '\n' char
                        break;
                    }
                    fs.Position--;
                }
                // fs.Position will be right after the '\n' char or position 0 if no '\n' char
                byte[] bytes = new System.IO.BinaryReader(fs).ReadBytes((int)(fs.Length - fs.Position));
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }
    }
