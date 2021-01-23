    protected void Page_Load(object sender, EventArgs e)
    {
       
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["DictionaryConnection"].ToString();
        using (SqlConnection conn = new SqlConnection(strConn))
        {
            conn.Open();
            string strSQL = "Select top(100) * from Parts";
            
            SqlCommand command = new SqlCommand(strSQL, conn);
            SqlDataReader sdr = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            sdr.Close();
            StringBuilder sbOut = new StringBuilder();
            sbOut.Append("<table border=\"1\">");
            sbOut.Append("<tr>");
            foreach (DataColumn dc in dt.Columns)
            {
                sbOut.Append("<th>" + dc.ColumnName + "</th>");
            }
            sbOut.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
         
            sbOut.Append("<tr>");
            foreach (DataColumn dc in dt.Columns)
            {
                string strOut = "";
                if (dr[dc] != null)
                {
                    if (dc.ColumnName=="Part_h")
                    {
                        int euckrCodepage = 949;//949;//51949;
                        
                        System.Text.Encoding originalEncoding = System.Text.Encoding.GetEncoding(1252);
                        
                        System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(euckrCodepage);
                        StringBuilder sbEncoding= new StringBuilder();
                        sbEncoding.Append("RAW: " + dr[dc].ToString() + "<br />");
                        
                       byte[] rawbytes= originalEncoding.GetBytes(dr[dc].ToString());
                       string s = euckr.GetString(rawbytes);
                        sbEncoding.Append("STRING AS "+euckr.EncodingName+": " + s + "<br />");
                       
                        strOut = sbEncoding.ToString();
                    }
                    else
                    {
                    strOut = dr[dc].ToString();    
                    }
                    
                }
                sbOut.Append("<td>" + strOut + "</td>");
            }
                sbOut.Append("</tr>");
            }
            sbOut.Append("</table>");
        conn.Close();
        lblText.Text = sbOut.ToString();
        }
      
    }
