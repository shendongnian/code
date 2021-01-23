        private void btnShow(object sender, EventArgs e)
    {
        DataTable CL = new DataTable();
        DataRow rt;
        DataTable dt = new DataTable();
        DataRow row;
        CL.Columns.Add(new System.Data.DataColumn("ID", typeof(string)));
        CL.Columns.Add(new System.Data.DataColumn("Name", typeof(string)));           
        for (int i = 0; i< dataGridView1.Rows.Count; i++)
        {
            rt = CL.NewRow();
            rt[0] = dataGridView1.Rows[i].Cells[0].Value.ToString();
            rt[1] = dataGridView1.Rows[i].Cells[1].Value.ToString();
            CL.Rows.Add(rt);
        }
        IEnumerable<DataRow> results = from myRow in CL.AsEnumerable()
                                       where myRow.Field<string>("ID") == "1"
                                       select myRow;
                foreach (var re in results)
                {
                    row = dt.NewRow();
                    dt.Rows.Add(st.Field<string>("Name"));
                }
       dataGridView2.DataSource = dt;
     }    
