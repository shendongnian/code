            DataTable DT1 = new DataTable();
        DT1.Columns.Add("c_" + DT1.Columns.Count);
        DT1.Columns.Add("c_" + DT1.Columns.Count);
        DT1.Columns.Add("c_" + DT1.Columns.Count);
        DataRow DR = DT1.NewRow();
        DR[0] = 0;
        DR[1] = 1;
        DR[2] = 2;
        DT1.Rows.Add(DR);
        DataTable DT2 = new DataTable();
        DT2.Columns.Add("c_" + DT2.Columns.Count);
        DT2.Columns.Add("c_" + DT2.Columns.Count);
        DT2.Columns.Add("c_" + DT2.Columns.Count);
        DT2.Columns.Add("c_" + DT2.Columns.Count);
        DR = DT2.NewRow();
        DR[0] = 0;
        DR[1] = 1;
        DR[2] = 2;
        DR[3] = 3;
        DT2.Rows.Add(DR);
        DT1.Merge(DT2);
        Trace.IsEnabled = true;
        DataTable DT_3=DT1.DefaultView.ToTable(true,new string[]{"c_1","c_2","c_0"});
        foreach (DataRow CDR in DT_3.Rows)
        {
            Trace.Warn("val",CDR[1]+"");//you will find only one data row
        }
