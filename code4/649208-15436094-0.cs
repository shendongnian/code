    public bool IsValidString(string s)
    {
      string[] strs = s.Split(' ');
      int i = 0;
      if (strs.Length != 2)
        return false;
      return (int.TryParse(strs[1], out i);
    }
