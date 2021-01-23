    private void timer_Tick(object sender, EventArgs e)
    {
        int count = dataTable.Rows.Count;
        if (count > 0)
        {
            int time;
            for (int i = 0; i < count; i++)
            {
                time = Convert.ToInt16(dataTable.Rows[i][2]);
                if (time > 0)
                    dataTable.Rows[i][2] = time - 1;
            }
        }
    }
