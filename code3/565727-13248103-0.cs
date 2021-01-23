    void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
        dt.Rows.Clear();
        dt.Columns.Clear();
        dt.Columns.Add("Column1");
        for (int i = 0; i < 5; i++)
        {
            DataRow r = dt.NewRow();
            r[0] = i;
            dt.Rows.Add(r);
        }
        dgv.Invoke((MethodInvoker) delegate() { dgv.Refresh(); });
    }
