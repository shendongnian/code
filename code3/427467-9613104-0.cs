        using system.data.Sqlclient;
        using system.IO;
        using system.Data;
      //function to store the fingerprint in database
      public void AddUser(string name)
        {
            // Read the file and convert it to Byte Array//,byte[] pf,int length
            string filePath = @"D:\10.fpt";
            string filename = Path.GetFileName(filePath);
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();
            //insert the file into database
           SqlConnection cn = new SqlConnection(connstring);
           SqlCommand cmd = new SqlCommand("adduser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@fp", SqlDbType.Binary).Value = bytes;
            
            cn.Open(); cmd.ExecuteNonQuery();
            cn.Close();
            
        }
        //retrieve fingerprint from database
        public void FingerPrintRtvl(string uid)
        {
            //retrieving the file from the database
          SqlConnection  cn = new SqlConnection(connstring);
           SqlDataAdapter adp = new SqlDataAdapter("fingerprintrtvl", cn);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@uid", Convert.ToInt32(uid));
            DataSet ds = new DataSet("MyImages");
            cn.Open();
            adp.Fill(ds, "MyImages");
            cn.Close();
            //storing the file in byte array
            byte[] MyData = new byte[0];
            DataRow myRow;
            myRow = ds.Tables["MyImages"].Rows[0];
            MyData = (byte[])myRow["fp"];
            int ArraySize = new int();
            ArraySize = MyData.GetUpperBound(0);
            string temp = System.IO.Path.GetTempPath();
            string fpFile = "D:\\" + "Aadhaarfingerprint.fpt";
            //saving the byte array in the local drive
            FileStream fs = new FileStream(fpFile, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Write(MyData, 0, ArraySize);
            fs.Close();
            
        }
 
