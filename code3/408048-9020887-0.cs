    System.Data.DataSet reportData = new System.Data.DataSet();
    System.Net.WebRequest request= System.Net.WebRequest.Create(reportDataPath);
    
    using (System.Net.WebResponse response =   (System.Net.HttpWebResponse)request.GetResponse()) {
        using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
            reportData.ReadXml(sr);
        }
    }
   
