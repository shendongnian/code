    using (StreamReader sr = new StreamReader(path)) 
     {
          foreach(string line = GetLine(sr)) 
          {
               //
          }
     }
    
        IEnumerable<string> GetLine(StreamReader sr)
        {
            while (!sr.EndOfStream)
                yield return new string(GetLineChars(sr).ToArray());
        }
        IEnumerable<char> GetLineChars(StreamReader sr)
        {
            if (sr.EndOfStream)
                yield break;
            var c1 = sr.Read();
            if (c1 == '\\')
            {
                var c2 = sr.Read();
                if (c2 == 'r')
                {
                    var c3 = sr.Read();
                    if (c3 == '\\')
                    {
                        var c4 = sr.Read();
                        if (c4 == 'n')
                        {
                            yield break;
                        }
                        else
                        {
                            yield return (char)c1;
                            yield return (char)c2;
                            yield return (char)c3;
                            yield return (char)c4;
                        }
                    }
                    else
                    {
                        yield return (char)c1;
                        yield return (char)c2;
                        yield return (char)c3;
                    }
                }
                else
                {
                    yield return (char)c1;
                    yield return (char)c2;
                }
            }
            else
                yield return (char)c1;
        }
