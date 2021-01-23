    // define connection string and select statement
    // I used AdventureWorks 2012 database - change to match *YOUR* environment
    string connectionString = "server=.;database=AdventureWorks2012;integrated security=SSPI;";
    string query = "SELECT ThumbNailPhoto FROM Production.ProductPhoto";
    
    // define a list of "Image" objects 
    List<Image> listOfImages = new List<Image>();
    // using the SqlConnection and SqlCommand ....
    using(SqlConnection conn = new SqlConnection(connectionString))
    using (SqlCommand selectCmd = new SqlCommand(query, conn))
    {
         // open connection
         conn.Open();
         // execute SqlCommand to return a SqlDataReader
         using (SqlDataReader rdr = selectCmd.ExecuteReader())
         {
             // iterate over the reader
             while (rdr.Read())
             {
                  // load the bytes from the database that represent your image
                  var imageBytes = (byte[]) rdr[0];
                  // put those bytes into a memory stream and "rewind" the memory stream
                  MemoryStream memStm = new MemoryStream(imageBytes);
                  memStm.Seek(0, SeekOrigin.Begin);
                  // create an "Image" from that memory stream
                  Image image = Image.FromStream(memStm);
                  // add image to list 
                  listOfImages.Add(image);
             }
        }
        conn.Close();
    }
