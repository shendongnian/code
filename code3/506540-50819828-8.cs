    public static class UTF8FileLastLineReader
    {
        // file at path must be utf8 encoded
        public static string ReadLastLineFromUTF8EncodedFile(string path)
        {
            using (System.IO.Stream fs = System.IO.File.OpenRead(path))
            {
                int b;
                fs.Position = fs.Length;
                while (fs.Position > 0)
                {
                    fs.Position--;
                    b = fs.ReadByte();
                    if (b < 0)
                    {
                        // the only way this should happen is if someone truncates the file out from underneath us while we are reading backwards
                        throw new System.IO.IOException("Error reading from file at " + path);
                    }
                    if (b == '\n')
                    {
                        break;
                    }
                    fs.Position--;
                }
                byte[] bytes = new System.IO.BinaryReader(fs).ReadBytes((int)(fs.Length - fs.Position));
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }
    }
