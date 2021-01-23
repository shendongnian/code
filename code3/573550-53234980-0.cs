    public static bool ReadWavFile(string filename, out float[] L, out float[] R)
            {
                L = R = null;
    
                try
                {
                    using (FileStream fs = File.Open(filename, FileMode.Open))
                    {
                        BinaryReader reader = new BinaryReader(fs);
    
                        // chunk 0
                        int chunkID = reader.ReadInt32();
                        int fileSize = reader.ReadInt32();
                        int riffType = reader.ReadInt32();
    
    
                        // chunk 1
                        int fmtID = reader.ReadInt32();
                        int fmtSize = reader.ReadInt32(); // bytes for this chunk
                        int fmtCode = reader.ReadInt16();
                        int channels = reader.ReadInt16();
                        int sampleRate = reader.ReadInt32();
                        int byteRate = reader.ReadInt32();
                        int fmtBlockAlign = reader.ReadInt16();
                        int bitDepth = reader.ReadInt16();
    
                        if (fmtSize == 18)
                        {
                            // Read any extra values
                            int fmtExtraSize = reader.ReadInt16();
                            reader.ReadBytes(fmtExtraSize);
                        }
    
    
                        // chunk 2 -- HERE'S THE NEW STUFF (ignore these subchunks, I don't know what they are!)
                        int bytes;
                        while(new string(reader.ReadChars(4)) != "data")
                        {
                            bytes = reader.ReadInt32();
                            reader.ReadBytes(bytes);
                        }
    
                        // DATA!
                        bytes = reader.ReadInt32();
                        byte[] byteArray = reader.ReadBytes(bytes);
    
                        int bytesForSamp = bitDepth / 8;
                        int samps = bytes / bytesForSamp;
    
    
                        float[] asFloat = null;
                        switch (bitDepth)
                        {
                            case 64:
                                double[]
                                asDouble = new double[samps];
                                Buffer.BlockCopy(byteArray, 0, asDouble, 0, bytes);
                                asFloat = Array.ConvertAll(asDouble, e => (float)e);
                                break;
                            case 32:
                                asFloat = new float[samps];
                                Buffer.BlockCopy(byteArray, 0, asFloat, 0, bytes);
                                break;
                            case 16:
                                Int16[]
                                asInt16 = new Int16[samps];
                                Buffer.BlockCopy(byteArray, 0, asInt16, 0, bytes);
                                asFloat = Array.ConvertAll(asInt16, e => e / (float)Int16.MaxValue);
                                break;
                            default:
                                return false;
                        }
    
                        switch (channels)
                        {
                            case 1:
                                L = asFloat;
                                R = null;
                                return true;
                            case 2:
                                L = new float[samps];
                                R = new float[samps];
                                for (int i = 0, s = 0; i < samps; i++)
                                {
                                    L[i] = asFloat[s++];
                                    R[i] = asFloat[s++];
                                }
                                return true;
                            default:
                                return false;
                        }
                    }
                }
                catch
                {
                    Debug.WriteLine("...Failed to load note: " + filename);
                    return false;
                    //left = new float[ 1 ]{ 0f };
                }
                
            }
