    string tosort = " Arun 2012, Gopi 2010, Dinesh 2012. Computer Networks, Tata McGraw Hill. 745:19-22";
    string sortedAuthors = "";
    string sortedTexts = "";
    List<string> mylist = tosort.Split(new[] { ',', '.' }).ToList<string>();
    mylist.Sort(); int i;
    foreach (var n in mylist)
    {
        if (Int32.TryParse(n.Substring(n.IndexOf(' ')).Trim(), out i))
        {
            sortedAuthors += (n + ", ");
        }
        else
        {
            sortedTexts += (n + ", ");
        }
    }
    string final = sortedAuthors + ", " + sortedTexts;
