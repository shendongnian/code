                   private void frm1_Load(object sender, EventArgs e)
        {
                AutoCompleteStringCollection namecollectionF = new AutoCompleteStringCollection();
            BLL objbll1 = new BLL();
            SqlDataReader dReader = objbll1.SelectNamelistF();
            if (dReader.HasRows == true)
            {
                while (dReader.Read())
                    
                    namecollectionF.Add(dReader["Name"].ToString());
            }
            else
            {
                MessageBox.Show("Data not found");
            }
            dReader.Close();
            txtForooshande.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtForooshande.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtForooshande.AutoCompleteCustomSource = namecollectionF;
           }
        
