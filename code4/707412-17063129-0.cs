    using (OracleConnection connection = new OracleConnection(connectionString))
        {
    MessageBox.Show("Recipe Rated");
                            OracleCommand cm = new OracleCommand("select round(avg(rating),1) from rates where id_rec = "+id);
    
            try
                        {
                                                    
                            cm.Connection = connection;
    connection.Open(); //oracle connection object
                            OracleDataReader reader = cm.ExecuteReader();
                            reader.Read();
                            textBox5.Text =""+reader.GetInt16(0);
                        }
    }
