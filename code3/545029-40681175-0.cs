    static DataTable GetTable()
    {
        // Here we create a DataTable with four columns.
        DataTable table = new DataTable();
        table.Columns.Add("Weight", typeof(int));
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("Breed", typeof(string));
        table.Columns.Add("Date", typeof(DateTime));
        // Here we add five DataRows.
        table.Rows.Add(57, "Koko", "Shar Pei", DateTime.Now);
        table.Rows.Add(130, "Fido", "Bullmastiff", DateTime.Now);
        table.Rows.Add(92, "Alex", "Anatolian Shepherd Dog", DateTime.Now);
        table.Rows.Add(25, "Charles", "Cavalier King Charles Spaniel", DateTime.Now);
        table.Rows.Add(7, "Candy", "Yorkshire Terrier", DateTime.Now);
        return table;
    }
