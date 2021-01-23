    void myThread()
    {
        using (DataTable dtTemp = DbConnection.db_Select_DataTable(srQuery))
        {
            foreach (DataRow drw in dtTemp.Rows)
            {
                DataRow tmp = drw;
                this.Dispatcher.BeginInvoke(new Action(delegate()
                {
                    listBox1.Items.Add(tmp["Value"].ToString());
                }));
            }
        }
    }
