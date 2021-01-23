    public static AutoCompleteStringCollection getSuggestedNames(string namepart)
    {
        string query = "SELECT name FROM worker WHERE name LIKE '%"+namepart+"%';";
        string[] namecolumn = { "name" };
        List<string>[] names = getValues(query,namecolumn);
        AutoCompleteStringCollection namec = new AutoCompleteStringCollection();
        for (int i = 0; i < names[0].Count; i++)
            if (names[0][i]!=null) namec.Add(names[0][i]);
        return namec;
    }
