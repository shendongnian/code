    private void btnShowImage_Click(object sender, EventArgs e)
    {
        string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\\PIS(ACU).mdb;";
        Con = new OleDbConnection(@constr);
        Con.Open();
        Com = new OleDbCommand();
        Com.Connection = Con;     
        Com.CommandText = "SELECT Photo FROM PatientImages WHERE Patient_Id =  " + val + " ";
        OleDbDataReader reader = Com.ExecuteReader();
        if (reader.Read())
        {
            byte[] picbyte = reader["Photo"] as byte[] ?? null;
            if (picbyte != null)
            {
                MemoryStream mstream = new MemoryStream(picbyte);
                pictureBoxForImage.Image = System.Drawing.Image.FromStream(mstream);
            {
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(mstream);
        }
    }
