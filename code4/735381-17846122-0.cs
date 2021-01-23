    public string example(IReadOnlyList<byte> someListIGotSomewhere, Encoding e)
    {
     string retVal = null;
     if(e.IsSingleByte)
     {
         retVal = string.Join("",someListIGotSomewhere.Select(b=>e.GetString(new byte[]{b})));
     }
     else
     {
       StringBuilder sb = new StringBuilder(someListIGotSomewhere.Count()/2);
       var enumerator = someListIGotSomewhere.GetEnumerator();
       var buffer = new byte[2]
       while(enumerator.MoveNext())
       {
         buffer[0] = enumerator.Current;
         buffer[1] = enumerator.MoveNext()?enumerator.Current:0;
         sb.Append(e.GetString(buffer));
       }
       retVal = sb.ToString();
     }
     return retVal;
    }
