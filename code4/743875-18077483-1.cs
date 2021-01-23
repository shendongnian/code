                            if (bsize != ms.Length)
                            {
                                bsize = ms.Length;
                                writer.Write((int)ms.Length);
                                writer.Write(ms.GetBuffer(), 0, (int)ms.Length);
                            }
