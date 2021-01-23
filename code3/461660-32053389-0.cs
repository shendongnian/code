        public async Task<HttpResponseMessage> PostFormDataAsync()    //async is used for defining an asynchronous method
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
	        }
            var fileLocation = "";
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            MultipartFormDataStreamProvider provider = new MultipartFormDataStreamProvider(root);  //Helps in HTML file uploads to write data to File Stream
            try
            {
                // Read the form data.
        	await Request.Content.ReadAsMultipartAsync(provider);
                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName); //Gets the file name
                    var filePath = file.Headers.ContentDisposition.FileName.Substring(1, file.Headers.ContentDisposition.FileName.Length - 2); //File name without the path
                    File.Copy(file.LocalFileName, file.LocalFileName + filePath); //Save a copy for reading it
                    fileLocation = file.LocalFileName + filePath; //Complete file location
                }
		HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, recordStatus);
                return response;
	}
   	catch (System.Exception e)
        {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
        }
    }
    public void ReadFromExcel()
    {
	try
            {
                DataTable sheet1 = new DataTable();
                OleDbConnectionStringBuilder csbuilder = new OleDbConnectionStringBuilder();
                csbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
                csbuilder.DataSource = fileLocation;
                csbuilder.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");
                string selectSql = @"SELECT * FROM [Sheet1$]";
                using (OleDbConnection connection = new OleDbConnection(csbuilder.ConnectionString))
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    connection.Open();
                    adapter.Fill(sheet1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }          
    }
