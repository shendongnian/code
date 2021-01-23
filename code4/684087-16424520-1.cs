    string searchString = TextBox1.Text;
    ArrayList personarraylist = new ArrayList();
    foreach (Person a in originalpersonarraylist)
    {
        //Assuming that there is a Name property in Person Class.
        if (a.Name.StartsWith(searchString))
            personarraylist.Add(a);
    }
    ListBox1.DataSource = personarraylist;
