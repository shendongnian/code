    public void AddString(string s)
    {
      lock(this.LockObject)
      {
         StringBuilder.AppendLine(s);
      }
    } 
