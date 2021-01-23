        DataTable dt;
        private void InitDataTable()
        {
            dt = new DataTable();
            DataSet ds = new DataSet();
            ds.ReadXml("gjesteInfo.xml");
            ds.Tables.Add(dt);
            DataColumn dc1 = new DataColumn("Fullt navn");
            DataColumn dc2 = new DataColumn("Start dato");
            DataColumn dc3 = new DataColumn("Antall dager");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Rows.Add(gjestenavnInput.Text, datoInnsjekk.Text, antallDager.Text);
            ds.Merge(dt); //Merging the dataset with the table and preventing it to be overwritten
            
            ds.WriteXml("gjesteInfo.xml");
        }
        private void lagre_Click(object sender, EventArgs e)
        {
            InitDataTable();
            dt.Rows.Add(gjestenavnInput.Text, datoInnsjekk.Text, antallDager.Text);
            gjesterutenrom.Items.Add(gjestenavnInput.Text);
            gjestenavnInput.Text = "";
            datoInnsjekk.Text = "";
            antallDager.Text = "";
        }
