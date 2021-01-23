        public static byte[][] SplitBytesByDelimiter(byte[] data, byte delimiter)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (data.Length < 1) return null;
            List<byte[]> retList = new List<byte[]>();
            int start = 0;
            int pos = 0;
            byte[] remainder = null; // in case data found at end without terminating delimiter
            while (true)
            {
                // Console.WriteLine("pos " + pos + " start " + start);
                if (pos >= data.Length) break;
                if (data[pos] == delimiter)
                {
                    // Console.WriteLine("delimiter found at pos " + pos + " start " + start);
                    // separator found
                    if (pos == start)
                    {
                        // Console.WriteLine("first char is delimiter, skipping");
                        // skip if first character is delimiter
                        pos++;
                        start++;
                        if (pos >= data.Length)
                        {
                            // last character is a delimiter, yay!
                            remainder = null;
                            break;
                        }
                        else
                        {
                            // remainder exists
                            remainder = new byte[data.Length - start];
                            Buffer.BlockCopy(data, start, remainder, 0, (data.Length - start));
                            continue;
                        }
                    }
                    else
                    {
                        // Console.WriteLine("creating new byte[] at pos " + pos + " start " + start);
                        byte[] ba = new byte[(pos - start)];
                        Buffer.BlockCopy(data, start, ba, 0, (pos - start));
                        retList.Add(ba);
                        start = pos + 1;
                        pos = start;
                        if (pos >= data.Length)
                        {
                            // last character is a delimiter, yay!
                            remainder = null;
                            break;
                        }
                        else
                        {
                            // remainder exists
                            remainder = new byte[data.Length - start];
                            Buffer.BlockCopy(data, start, remainder, 0, (data.Length - start));
                        }
                    }
                }
                else
                {
                    // payload character, continue;
                    pos++;
                }
            }
            if (remainder != null)
            {
                // Console.WriteLine("adding remainder");
                retList.Add(remainder);
            }
            return retList.ToArray();
        }
