        public string[] dgv_Headers = new string[] { "Id","Hotel", "Lunch", "Dinner", "Excursions", "Guide", "Bus" }; // This defined at Public partial class
  
        private void SetDgvHeader()
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 7;
            dgv.RowHeadersVisible = false;
            int Nbr = int.Parse(daysBox.Text);  // in my method it's the textbox where i keep the number of rows I have to use
            dgv.Rows.Add(Nbr);
            for(int i =0; i<Nbr;++i)
                dgv.Rows[i].Height = 20;
            for (int i = 0; i < dgv_Headers.Length; ++i)
            {
                if(i==0)
                    dgv.Columns[i].Visible = false;  // I need an invisible cells if you don't need you can skip it
                else
                    dgv.Columns[i].Width = 78;
                dgv.Columns[i].HeaderText = dgv_Headers[i];
            }
            dgv.Height = (Nbr* dgv.Rows[0].Height) + 35;
            dgv.AllowUserToAddRows = false;
        }
