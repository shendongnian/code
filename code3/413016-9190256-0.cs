    using System.Reflection;
    using System.IO;
    
    //Attach image
    object missing = System.Reflection.Missing.Value;
    
    Image car = OutlookAddIn1.Properties.Resources.Car;
    
    string path = Path.Combine(Path.GetTempPath(), "Car.jpg");
    car.Save(path);
    
    if (File.Exists(path))
      {
       mail.Attachments.Add(path,Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue,missing, missing);
       File.Delete(path);
      }
