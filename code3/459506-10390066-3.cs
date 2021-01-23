                if (this.MustEncrypt)
                    bytes2 = RijndaelEncrptor.Instance.Encrypt(bytes2);
                // Create a buffer large enough to hold the encrypted message and size bytes
                byte[] data = new byte[8 + bytes2.Length];
                // Add the message size
                BitConverter.GetBytes(bytes2.Length).CopyTo(data, 0);
                BitConverter.GetBytes(this.MustEncrypt).CopyTo(data, 4);
                // Add the message data
                bytes2.CopyTo(data, 8);
                return data;
            }
        }
        static public MessageBase Deserialize(byte[] buffer)
        {
            int length = BitConverter.ToInt32(buffer, 0);
            bool mustDecrypt = BitConverter.ToBoolean(buffer, 4);
            MessageBase b = null;
            try
            {
                b = MessageBase.Deserialize(buffer, 8, length, mustDecrypt);
            }
            catch { }
            return b;
        }
        static public MessageBase Deserialize(byte[] buffer, int offset, int length, bool mustDecrypt)
        {
            // Create a buffer and initialize it with data from
            // the input buffer offset by the specified offset amount
            // and length determined by the specified length
            byte[] data = new byte[length];
            Buffer.BlockCopy(buffer, offset, data, 0, length);
