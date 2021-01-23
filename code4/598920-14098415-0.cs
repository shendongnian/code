    SPWeb oWeb = SPContext.Current.Web;
    SPList lstTarget = oWeb.Lists.TryGetList("DDC");
    
    Hashtable metaData = new Hashtable();
    
    metaData.Add("Field1 Name", "Field1 Value");
    metaData.Add("Field2 Name", "Field2 Value");
    metaData.Add("Field3 Name", "Field3 Value");
    
    byte[] bytes = File.ReadAllBytes("c:\folder\myfile.txt"); //Set path to file to be uploaded in document library.
    
    oWeb.AllowUnsafeUpdates = true;
    SPFile destfile = lstTarget.RootFolder.Files.Add("myfile.txt", bytes, metaData, true);
    oWeb.AllowUnsafeUpdates = false;
