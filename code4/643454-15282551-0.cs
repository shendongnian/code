        private void LoadEmpName()
        {
            try
            {
                sc.Open();
                //it will return all employees containing word waiter in Column JobTitle.
                cmd.CommandText = "select * from myEmployees where JobTitle like '%waiter%' ";
                
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   lstNames.Items.Add(dr[1].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
               sc.Close();
            }
        }
