        ListBox lbox;
        private void IletisimBilgileriDoldur()
        {
            try
            {
                string strQuery= "Select adres From tblIletisimBilgileri Where adres <> '';";
                veri = new OleDbCommand(strQuery,strConn);
                veri.CommandType = CommandType.Text;
                if (strConn.State == ConnectionState.Closed) strConn.Open();
                oku = veri.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(oku);
                oku.Close();
                txtAdres.AutoCompleteCustomSource.Clear();
                if (dt.Rows.Count >= 0)
                {
                    lbox = new ListBox();
                    for (int count = 0; count < dt.Rows.Count; count++)
                    {
                        lbox.Items.Add(dt.Rows[count]["adres"].ToString());
                    }
                }
                txtAdres.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtAdres.AutoCompleteSource = AutoCompleteSource.CustomSource;
                if (strConn.State == ConnectionState.Open) strConn.Close();
            }
            catch (Exception)
            {
                if (strConn.State == ConnectionState.Open) strConn.Close();
            }
        }
        private void txtAdres_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var x = txtAdres.Left;
            var y = txtAdres.Top + txtAdres.Height;
            var width = txtAdres.Width;
            const int height = 120;
            lbox.SetBounds(x, y, width, height);
            lbox.KeyDown += lbox_SelectedIndexChanged;
            lbox.DoubleClick += lbox_DoubleClick;
            gbxAdres.Controls.Add(lbox);
            lbox.BringToFront();
            lbox.Show();
            ActiveControl = txtAdres;
        }
        void lbox_DoubleClick(object sender, EventArgs e)
        {
            txtAdres.Text = ((ListBox)sender).SelectedItem.ToString();
            lbox.Hide();
        }
