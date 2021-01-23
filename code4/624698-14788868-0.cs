            int[] ll;
            using (FileStream fs = File.OpenRead("image-text-16.txt"))
            {
                int numberEntries = fs.Length / sizeof(int);
                using (BinaryReader br = new BinaryReader(fs))
                {
                    ll = new int[numberEntries];
                    for (int i = 0; i < numberEntries; ++i)
                    {
                        ll[i] = br.ReadInt32();
                    }
                }
            }
            // ll is the result
