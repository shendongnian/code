        string searchString = Textbox1.Text;
    //Retrive the person data for some location
    ArrayList personarraylist = getPersonData();
    foreach (Person a in personarraylist)
    {
        if (searchString.contains(a.ToString()))
        {
            personarraylist.Add(a);
        }
    }
    ListBox1.DataSource = personarraylist;
