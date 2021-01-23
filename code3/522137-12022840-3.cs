        private void btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.sqlConnection1.Open();
                if (sqlCommand1.Parameters.Count ==0 )
                {
                    this.sqlCommand1.CommandText="INSERT INTO tblImgData(ID," + 
                                   " Name,Picture) values(@ID,@Name,@Picture)";
                    this.sqlCommand1.Parameters.Add("@ID", 
                                     System.Data.SqlDbType.Int,4);
                    this.sqlCommand1.Parameters.Add("@Name", 
                                     System.Data.SqlDbType.VarChar,50);
                    this.sqlCommand1.Parameters.Add("@Picture", 
                                     System.Data.SqlDbType.Image);
                }
        
                this.sqlCommand1.Parameters["@ID"].Value=this.editID.Text;
                this.sqlCommand1.Parameters["@Name"].Value=this.editName.Text;
                this.sqlCommand1.Parameters["@Picture"].Value=this.m_barrImg;
        
                int iresult=this.sqlCommand1.ExecuteNonQuery();
                MessageBox.Show(Convert.ToString(iresult));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.sqlConnection1.Close();
            }
        }
