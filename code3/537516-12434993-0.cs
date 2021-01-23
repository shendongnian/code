    List<Customers> lst = new List<Customers>();
    string[] str = System.IO.File.ReadAllText(@"C:\CutomersFile.txt")
                                 .Split(new string[] { Environment.NewLine }, 
                                                       StringSplitOptions.None);
    for (int i = 0; i < str.Length; i++)
    {
        string[] s = str[i].Split(',');
        Customers c = new Customers();
        c.Name = s[0];
        c.City = s[1];
        c.Balance = Convert.ToDouble(s[2]);
        c.CardNumber = Convert.ToInt32(s[0]);
        lst.Add(c);
    }
