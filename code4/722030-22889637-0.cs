    public Byte[] RECIBE()
                    {
                        int count = serialPort1.BytesToRead;
                        if (count > 0)
                        {
                            List<Byte> bytes = new List<Byte>();
                            bool ETX = false;
                            while (ETX == false)
                            {
                                Byte b = Convert.ToByte(serialPort1.ReadByte());
                                if (b == 0x06)
                                {
                                    bytes.Add(b);
                                    return bytes.ToArray();
                                }
                                if (b != 0x03)
                                {
                                    bytes.Add(b);
                                }
                                else
                                {
                                    bytes.Add(b);
                                    ETX = true;
                                }
                            }
                            Byte b2 = Convert.ToByte(serialPort1.ReadByte());
                            bytes.Add(b2);
                            return bytes.ToArray();
                        }
                        else
                        {
                            return null;
                        }
                    }
