    var verifyInfos = new List<VerifyInfo>();
   
    for(int i = 0; i < dataGridView1.RowCount - 1; i++)
    {
        var date = Convert.ToDateTime(
            dataGridView1.Rows[i].Cells[2].Value);
        if(date <= DateTime.Now)
        {
            verifyInfos.Add(new VerifyInfo
            {
                CodUser = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value),
                DataFim = Convert.ToDateTime(
                    dataGridView1.Rows[i].Cells[2].FormattedValue),
                Nome = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value)
            });
        }
    }
