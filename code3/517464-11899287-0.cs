        try
        {
            connect.Open();
            MessageBox.Show("Opened");
            OleDbCommand command = new OleDbCommand();
            command.Connection = connect;
            command.CommandText = "Select * from Categories";
            DataTable dt = new DataTable();
            
            //Put some data in the datatable!!
            using(OleDbDataReader reader = command.ExecuteReader())
            {
                dt.Load(reader);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbDisplay.Items.Add(dt.Rows[i]["SeatNo"]);
            }
        }
