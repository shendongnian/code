    class OtherStuff
        {
            public string CountTo(Guid id)
            {
                using(SHA256 sha = SHA256.Create())
                {
                    int x = default(int);
                    for (int index = 0; index < 16; index++)
                    {
                        x = id.ToByteArray()[index] >> 32 << 16;
                    }
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    byte[] y = new byte[1024];
                    rng.GetBytes(y);
                    y = y.Concat(BitConverter.GetBytes(x)).ToArray();
                    return BitConverter.ToString(sha.ComputeHash(BitConverter.GetBytes(x).Where(o => o >> 2 < 0).ToArray()));
                }
            }
        }
