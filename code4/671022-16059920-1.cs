    List<string> mylist = new List<string>();
        mylist.Add("item1");
        mylist.Add("item2");
        for (int i = 0; i < mylist.Count; i++)
        {
            mylist[i] = mylist[i].Replace("i", "o");
        }
