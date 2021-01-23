    public void Main()
    {
        DoSomethingMethod((DataTable)dataGridView1.DataSource);
    }
    private void DoSomethingMethod(DataTable dataTable)
    {
        foreach (DataRow row in dataTable.Rows)
        {
            double myX = Convert.ToDouble(row["Latt"]);
            double myY = Convert.ToDouble(row["Long"]);
        }
    }
