                FileStream f = new FileStream("G:\\text.txt",FileMode.Open);
                for (int i = 0; i < f.Length; i += 4)
                {
                    byte[] b = new byte[4];
                    int bytesRead = f.Read(b, 0, b.Length);
    
                    if (bytesRead < 4)
                    {
                        byte[] b2 = new byte[bytesRead];
                        Array.Copy(b, b2, bytesRead);
                        arrays.Add(b2);
                    }
                    else if (bytesRead > 0)
                        arrays.Add(b);
    
                    fs.Write(b, 0, b.Length);
                    byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                    fs.Write(newline, 0, newline.Length);
                }
