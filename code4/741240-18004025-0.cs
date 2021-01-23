    List<string> validExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".stl" };
    if (hcf.PostedFiles.Any(x => !validExtensions.Contains(x.FileName)))
    {
         lblMsg.Text = "Extension not supported";
         return;
    }    
    //rest of your code here. which by the way, looks better like this:
    foreach (var item in hcf.PostedFiles)
    {
       string guidResult = System.Guid.NewGuid().ToString();
       item.SaveAs(Server.MapPath("files\\") + guidResult.ToString() + extension);
    }
