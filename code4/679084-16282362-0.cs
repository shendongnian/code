    List<byte[]> Split(byte[] bArray)
            {
                List<byte[]> result = new List<byte[]>();
                List<byte> tmp = new List<byte>();
                int i, n = bArray.Length;
                for (i = 0; i < n; i++)
                {
                    if (bArray[i] == 0x13 && (i + 1 < n && bArray[i + 1] == 0x10))
                    {
                        result.Add(tmp.ToArray());
                        tmp.Clear();
                        i++;
                    }
                    else
                        tmp.Add(bArray[i]);
                }
                if (tmp.Count > 0)
                    result.Add(tmp.ToArray());
                return result;
            }
