    //ComboBox TextChanged Event
        private void txtName1_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter daTemp = new SqlDataAdapter("select Name from Names where Name like '" + txtName1.Text + "%'", strConnection);
            DataTable dtTemp = new DataTable();
            daTemp.Fill(dtTemp);
            MessageBox.Show(dtTemp.Rows.Count.ToString());
            String[] Names = new String[dtTemp.Rows.Count + 1];
            if (dtTemp.Rows.Count > 0)
            {
                for (int x = 0; x <= dtTemp.Rows.Count - 1; x++)
                {
                    Names[x] = dtTemp.Rows[x][0].ToString();
                }
            }
            else
            {
                MessageBox.Show("Data not found");
            }
            contextMenuStrip1.Items.Clear();
            for (int y = 0; y <= dtTemp.Rows.Count - 1; y++)
            {
                //Set The Desired Location (e.g. Besides of ComboBox) Of ContextMenuStrip
                contextMenuStrip1.Left = 80;
                contextMenuStrip1.Top = 90;
                contextMenuStrip1.Items.Add(Names[y].ToString());
                contextMenuStrip1.Visible = true;
            }
        }
