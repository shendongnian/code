    private void button7_Click(object sender, EventArgs e)
    {        
        ProductDetails.Items.Clear();
        SqlConnection con = new SqlConnection(@"server=xxx-PC; database= sample; integrated security= true");
        SqlCommand cmd = new SqlCommand("select * from tblproduct where prodname like @name;", con);
        cmd.Parameters.AddWithValue(textBox1.Text.Trim() + "%");
        SqlDataAdapter  da  = new SqlDataAdapter(cmd);
        DataTable       dt  = new DataTable();
        try
        {
            con.Open();
            da.Fill(dt);
        }
        catch (Exception e)
        { //exception handling here }
        finally { con.Close(); }
        foreach(DataRow dr in dt.Rows)
        {
            byte[]imgg =(byte[])dr["image"];
            if(imgg==null || imgg.length <= 0)
                pictureBox1.Image= null;
            else
            {
                pictureBox1.Image = ByteToImage(imgg);
            }
            ProductDetails.Items.Add(dr[0].ToString() + " \t" + 
                dr[1].ToString() + "\t" + 
                dr[2].ToString() + 
                dr[3].ToString());            
        }
    }
    // http://stackoverflow.com/questions/9576868/how-to-put-image-in-a-picture-box-from-a-byte-in-c-sharp
    public static Bitmap ByteToImage(byte[] blob)
    {
        MemoryStream mStream = new MemoryStream();
        byte[] pData = blob;
        mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
        Bitmap bm = new Bitmap(mStream, false);
        mStream.Dispose();
        return bm;
    }
