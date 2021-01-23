        //SELECT THE VALUES FROM XML USING C#
        
                <?xml version="1.0" encoding="iso-8859-1"?>
                <CONFIG>
                  <UsersList>
                    <SystemName>DOTNET-PC</SystemName>
                    <UserName>KARTHIKEYAN</UserName>
                    <ImagePath>C:\Users\DEVELOPER\AppData\Roaming\Office Messenger\assets\insta.jpg</ImagePath>
                    <PhotoPath>C:\Users\DEVELOPER\AppData\Roaming\Office Messenger\assets\NoPhoto.png</PhotoPath>
                    <UserStatus>Available</UserStatus>
                    <CustomStatus>Available</CustomStatus>
                    <theme>FF8B0000</theme>
                  </UsersList>
                </CONFIG>                       //XML DOCUMENT
            
            //C#
            
    DataSet ds = new DataSet();
    try
    {
       ds.ReadXml("C:\\config.xml");
    }
    catch { };
           
    if (ds.Tables.Count > 0)
    {
      var results = from myRow in ds.Tables[0].AsEnumerable() where myRow.Field<string>    ("SystemName") == SystemInformation.ComputerName select myRow;//ds.Tables[0] is <CONFIG> tag //in where SystemName=My system name to select the values from xml
      foreach (var cust in results)
      {
        string _myName = cust["UserName"].ToString();
        string _myLogoPath = cust["ImagePath"].ToString();
        string _customStatus = cust["CustomStatus"].ToString();
        string _myPhotoPath = cust["PhotoPath"].ToString();
      }
    }
      
        
    //CREATE XML FROM C#
         
    XDocument xmlDoc = XDocument.Load("C:\\config.xml");
    xmlDoc.Root.Add(new XElement("UsersList", new XElement("SystemName", SystemInformation.ComputerName), new XElement("UserName", SystemInformation.ComputerName), new XElement("ImagePath", _filesPath + "\\insta.jpg"), new XElement("PhotoPath", _filesPath + "\\NoPhoto.png"), new XElement("UserStatus", "Available"), new XElement("CustomStatus", "Available"), new XElement("theme", "000000")));
    xmlDoc.Save("C:\\config.xml");
