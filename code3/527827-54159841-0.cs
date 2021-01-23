        public void ProcessRequest(HttpContext context)
        {
            string constring = ConfigurationManager.ConnectionStrings["SQL_Connection_String"].ConnectionString;
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select image1 from TestGo where TestId=1", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            MemoryStream str = new MemoryStream();
            context.Response.Clear();
            Byte[] bytes = (Byte[])dr[0];
            string d = System.Text.Encoding.Default.GetString(bytes);
            byte[] bytes2 = Convert.FromBase64String(d);
            //context.Response.Write(d);
            Image img = Image.FromStream(new MemoryStream(bytes2));
            img.Save(context.Response.OutputStream, ImageFormat.Png);
            context.Response.Flush();
            str.WriteTo(context.Response.OutputStream);
            str.Dispose();
            str.Close();
            conn.Close();
            context.Response.End();
        }
