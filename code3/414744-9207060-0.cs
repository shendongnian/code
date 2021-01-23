        decimal sumaa = 0;
        DataTable suma = bonTableAdapter.Suma(DateTime.Now);
        foreach (DataRow r in suma.Rows)
        {
            sumaa += Convert.ToDecimal(r.ItemArray[0]);
        }
