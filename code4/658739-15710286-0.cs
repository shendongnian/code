    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (imgUpload.PostedFile != null)
        {
            BinaryReader b = new BinaryReader(imgUpload.InputStream);
            byte[] byteArray = b.ReadBytes(imgUpload.ContentLength);
            string sql = " INSERT INTO IMAGETBL(ID,IMAGE) VALUES(:ID, :IMAGE) ";
            OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVER_NAME=XE)));User Id=sakthi_studdb;Password=sakthi;");
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add("ID", OracleDbType.Int32, 4, ParameterDirection.Input);
                cmd.Parameters.Add("IMAGE", OracleDbType.Blob, byteArray, ParameterDirection.Input);
                cmd.ExecuteNonQuery();
                secondlabel.Text = "Image added to blob field";
            }
            catch (Exception ex)
            {
                secondlabel.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
        }
    }
