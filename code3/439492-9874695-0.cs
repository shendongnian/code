    public static IEnumerable<string> ReadChunks(this TextReader reader, string chunkSep)
    {
        var sb = new StringBuilder();
    
        var sepbuffer = new Queue<char>(chunkSep.Length);
        var sepArray = chunkSep.ToCharArray();
    
        while (reader.Peek() >= 0)
        {
            var nextChar = (char)reader.Read();
            if (nextChar == chunkSep[sepbuffer.Count])
            {
                sepbuffer.Enqueue(nextChar);
                if (sepbuffer.Count == chunkSep.Length)
                {
                    yield return sb.ToString();
                    sb.Length = 0;
                    sepbuffer.Clear();
                }
            }
            else
            {
                sepbuffer.Enqueue(nextChar);
                while (sepbuffer.Count > 0)
                {
                    sb.Append(sepbuffer.Dequeue());
                    if (sepbuffer.SequenceEqual(chunkSep.Take(sepbuffer.Count)))
                        break;
                }
            }
        }
        yield return sb.ToString() + new string(sepbuffer.ToArray());
    }
