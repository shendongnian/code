    public static void Import(DataTable table)
    {
        var dataContext = DataContext.Instance.Entities;
        foreach (DataRow row in table.Rows)
        {
            .......
            var dataRow = new DATA
            {
               .........
            };
            dataContext.AddToDATA(dataRow);
        }
        dataContext.SaveChanges();
        var data = datContext.whateverretreval();
        Data = data;
    }
