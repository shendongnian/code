    public ActionResult GetContact()
    {
        Response.Clear();
        Response.AddHeader("Content-disposition", string.Format("attachment; filename=\"{0}\";", "MyContact.vcf"));
        
                   //  VERY IMPORTANT!!!
        
                   //      Read the file as text, and then convert it to ASCII bytes.  
                   //      If ReadAllBytes is used, extra stray characters seem to appear and DROID fails.
        
                   //      Put the content type in the second parameter!!!
        
    
        var vCardFile = System.IO.File.ReadAllText(Server.MapPath("~/Contacts/MyContact.vcf"));
        return File(System.Text.Encoding.ASCII.GetBytes(vCardFile), "text/x-vcard");
    }
