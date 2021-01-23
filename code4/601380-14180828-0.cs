    internal static string ReadLine(this DataReader stream, ref int maxLength, Encoding encoding, char? termChar)
    {
        var maxLengthSpecified = maxLength > 0;
        int i;
        byte b = 0, b0;
        var read = false;
        using (var mem = new MemoryStream())
        {
            while (true)
            {
                b0 = b;
                i = stream.ReadByte();
                if (i == -1) break;
                else read = true;
                b = (byte)i;
                if (maxLengthSpecified) maxLength--;
                if (maxLengthSpecified && mem.Length == 1 && b == termChar && b0 == termChar)
                {
                    maxLength++;
                    continue;
                }
                if (b == 10 || b == 13)
                {
                    if (mem.Length == 0 && b == 10)
                    {
                        continue;
                    }
                    else break;
                }
                mem.WriteByte(b);
                if (maxLengthSpecified && maxLength == 0)
                    break;
            }
            if (mem.Length == 0 && !read) return null;
            return encoding.GetString(mem.ToArray(), 0, (int)mem.Length);
        }
    }
