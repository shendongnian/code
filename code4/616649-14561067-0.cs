    public class FileArray
    {
       Stream s;
    
       public this[int index]
       {
          get { s.Position = index * 4; return s.Read(); }
          set { s.Position = index * 4; s.Write(value); }
       }
    }
