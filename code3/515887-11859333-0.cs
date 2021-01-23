        private void btnSearch_Click(object sender, EventArgs e)
        {
            System.Data.OleDb.OleDbConnection MyCon ;
            System.Data.DataSet DtSet ;
            System.Data.OleDb.OleDbDataAdapter MyCommand ;
            //~~> Replace this with relevant file path
            MyCon = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Sample.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
            //~~> Replace this with the relevant sheet name
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyCon);
            MyCommand.TableMappings.Add("Table", "MyTable");
            DtSet = new System.Data.DataSet();
            
            //~~> Fill Dataset
            MyCommand.Fill(DtSet);
            
            //~~> Set Source
            dataGridView1.DataSource = DtSet.Tables[0];
            MyCon.Close();
        }
