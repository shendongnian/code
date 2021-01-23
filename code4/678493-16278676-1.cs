      [WebMethod]
        public void vFileUpload(string data, string strFileName)
        {
            try
            {
                string str = data.Length.ToString();
                string sDestinationScannedFiles = ConfigurationManager.AppSettings["DestinationScannedFiles"].ToString();
                //string filePath = Server.MapPath(sDestinationScannedFiles +  strFileName);
                string filePath = sDestinationScannedFiles + strFileName;
                File.WriteAllBytes(filePath, Convert.FromBase64String(data));
            }
