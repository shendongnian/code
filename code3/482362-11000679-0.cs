    bool InfoRepeated()
        {
            OleDbCommand cmd = new OleDbCommand();
			cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("SELECT cname FROM yourTable;");
            cmd.Connection = myCon;
			myCon.Open();
            try
            {
                OleDbDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (txt_cname.Text.Equals((rdr[0].ToString())))
                    {
                        myCon.Close();
                        return true;
                    }
                }
                myCon.Close();
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                myCon.Close();
                return false;
            }
        }
