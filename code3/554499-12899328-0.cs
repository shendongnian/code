      private void Form1_Load(object sender, EventArgs e)
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=C:\\Users\\KevinDW\\Desktop\\dotNET\\Week 5\\Prak1\\demo1.accdb";
    
            OleDbConnection conn = new OleDbConnection(connString);
    
            conn.Open();
    
            string sqlCmd = "SELECT CursusNaam FROM tblCursus";
    
            OleDbCommand cmd = new OleDbCommand(sqlCmd, conn);
    
            using (OleDBDataReader reader = cmd.ExecuteReader())
            {
                listBox1.Items.Add(reader);
            }
    
            conn.Close();
        }
    }
