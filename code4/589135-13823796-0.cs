      private void TabelaDinamimcaSucess(bool sucesso, int index, string host, string data, string tempo,string status)
    {
       string[] row = new string[] { index.ToString(), host, data, tempo,status };
       dataGridView1.Rows.Add(row);
        int number_of_rows = dataGridView1.RowCount -1;
        Bitmap b = new Bitmap((sucesso == true ? Properties.Resources.greenBall : Properties.Resources.redBall));
        Icon icon = Icon.FromHandle(b.GetHicon());
        dataGridView1.Rows[number_of_rows].Cells["img"].Value = icon;
        dataGridView1.Show();
    }
