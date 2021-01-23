    int iLength = 0; 
    int index = 0;
    DataTable dt = new DataTable();
    dt = SqlComm.SqlDataTable("SELECT * FROM Movie");
    object obj = new object();
    obj = SqlComm.SqlReturn("SELECT COUNT (yourTargetColumn) FROM yourTable");
    if (obj != null)                    
         iLength = Convert.ToInt32(obj); 
    string[] stringArray = new string[iLength];
    for (index = 0; index < iLength; index++) 
    {
         stringArray[index] = (string)dt.Rows[index]["yourTargetColumn"];                   
    }
    foreach (string barcode in barcodes)
    {    
         Label yourLabel = new Label();
         PH.Controls.Add(yourLabel);
    }
          
