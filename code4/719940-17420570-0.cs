    String conn = ("Server=127.0.0.1;Port=5432;User id=*******;Password=***;Database=database1;");
                try
                {
                    NpgsqlConnection objConn = new NpgsqlConnection(conn);
                    objConn.Open();
                    string strSelectCmd = "INSERT INTO weather (date, city, temp_hi, temp_lo) VALUES ('1994-11-29', 'Hayward', 54, 37);";
                   
                   NpgSqlCommand cmd=new NpgSqlCommand(strSelectCmd,objConn);
                   cmd.ExcuteNonquery();
                   
                   objConn.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
         }
