            private List<byte> Finalize(List<byte> packet)
            {
                int i = 1;
                while (i < packet.Count)
                {
                    if (packet[i] == 0x7D)
                    {
                        packet[i] = 0x7D;
                        packet.Insert(i+1, 0x5D);
                        i += 2;
                    }
                    else if (packet[i] == 0x7E) //Sync Byte
                    {
                        packet[i] = 0x7D;
                        packet.Insert(i+1, 0x5E);
                        i += 2;
                    }
                }
                return packet;
            }
