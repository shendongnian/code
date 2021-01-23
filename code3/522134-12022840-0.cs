     1. Create sql table
    
        CREATE TABLE [dbo].[tblImgData] (
    
            [ID] [int] NOT NULL ,
    
            [Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    
            [Picture] [image] NULL 
    
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    
     1. Get image from local computer
    
       
    
         protected void LoadImage()
            {
                try
                {
                    this.openFileDialog1.ShowDialog(this);
                    string strFn=this.openFileDialog1.FileName;
                    this.pictureBox1.Image=Image.FromFile(strFn);
                    FileInfo fiImage=new FileInfo(strFn);
                    this.m_lImageFileLength=fiImage.Length;
                    FileStream fs=new FileStream(strFn,FileMode.Open, 
                                      FileAccess.Read,FileShare.Read);
                    m_barrImg=new byte[Convert.ToInt32(this.m_lImageFileLength)];
                    int iBytesRead = fs.Read(m_barrImg,0, 
                                     Convert.ToInt32(this.m_lImageFileLength));
                    fs.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    
     1. Save image in database
    
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
