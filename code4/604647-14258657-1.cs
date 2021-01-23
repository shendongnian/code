        DataTable tvparameter = new DataTable();
        tvparameter.Columns.Add("Name", typeof(string));
        foreach (string name in names)
        {
          tvparameter.Rows.Add(name);
        }
