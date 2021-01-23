    XmlDocument xml = new XmlDocument();
    try
    {
        // assuming the location of the file is in the current directory 
        // assuming the file name be loadData.xml
        string myString = "./loadData.xml";
        xml.Load(myString);
    }
    catch (Exception ex)
    {
        System.IO.File.WriteAllText(@"C:\text.txt", myString + "\r\n\r\n" + ex.Message);
        throw ex;
    }
