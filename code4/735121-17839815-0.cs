    string lastItem = mylist[mylist.Count - 1];
    Foreach(string s in mylist)
    {
      if (s != lastItem)
        sw.Write(s + ",");
      else
        sw.Write(s);
    }
