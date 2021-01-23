                private static byte[] Rays(byte[] sigBytes)
                {
                    bool highMsbR = (sigBytes[0] & 0x80) != 0;
                    bool highMsbS = (sigBytes[20] & 0x80) != 0;  
                    
                    MemoryStream stream = new MemoryStream();
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write((byte)0x30);
                        int len = 44 + (highMsbR ? 1 : 0) + (highMsbS ? 1 : 0);
                        writer.Write((byte)len);
    
                        // r
                        writer.Write((byte)0x02);
                        writer.Write((byte)(highMsbR ? 21 : 20));
                        if (highMsbR)
                            writer.Write((byte)0); 
                        for (int i = 0; i < 20; i++)
                            writer.Write(sigBytes[i]); 
    
                        // s
                        writer.Write((byte)0x02);
                        writer.Write((byte)(highMsbS ? 21 : 20));
                        if (highMsbS)
                            writer.Write((byte)0);
                        for (int i = 20; i < 40; i++)
                            writer.Write(sigBytes[i]);
                    }
                    
                    byte[] bytes = stream.ToArray();
                    return bytes;
                }
