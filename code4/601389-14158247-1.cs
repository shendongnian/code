                using (MemoryStream MS = new MemoryStream(stream, 0, stream.Length))
                    {
                        MS.Write(stream, 0, stream.Length);
                        MS.Seek(0, SeekOrigin.Begin);
                        System.Drawing.Image img = System.Drawing.Image.FromStream(MS);
...
