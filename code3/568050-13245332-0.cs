    string randomFileName = Helpers.GetRandomFileName();
    string formTemplate = Server.MapPath("~/FormTemplate.pdf");
     string formOutput = Server.MapPath(string.Format("~/downloads/Forms/Form-{0}.pdf",    randomFileName));
 
    PdfReader reader = new PdfReader(formTemplate);
    PdfStamper stamper = new PdfStamper(reader, new System.IO.FileStream(formOutput,   System.IO.FileMode.Create));
    AcroFields fields = stamper.AcroFields;
 
    // set form fields
    fields.SetField("Date", DateTime.Now.ToShortDateString());
    fields.SetField("FirstName", user.FirstName);
    fields.SetField("LastName", user.LastName);
    fields.SetField("Address1", user.Address1);
    fields.SetField("Address2", user.Address2);
    fields.SetField("City", user.City);
    fields.SetField("State", user.State);
    fields.SetField("Zip", user.Zip);
    fields.SetField("Email", user.Email);
    fields.SetField("Phone", user.Phone);
 
    // set document info
    System.Collections.Hashtable info = new System.Collections.Hashtable();
    info["Title"] = "User Information Form";
    info["Author"] = "My Client";
    info["Creator"] = "My Company";
    stamper.MoreInfo = info;
 
     // flatten form fields and close document
    stamper.FormFlattening = true;
    stamper.Close();
