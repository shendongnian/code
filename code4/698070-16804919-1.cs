    [HttpPost]
    public ActionResult ShowBox(string message, HttpPostedFileBase file)
    {
        if (file == null || file.ContentLength == 0)
        {
            //override the message sent from the view
            message = "You did not specify a valid file to upload";
        } 
        else 
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"));
            file.SaveAs(path);
        }
        System.Text.StringBuilder response = new System.Text.StringBuilder();
        response.Append("<script language='javascript' type='text/javascript'>");
        response.Append(string.Format("    alert('{0}');", message));
        response.Append("    var uploader = document.getElementById('upload-button'); ");
        response.Append("    window.location.href = '/Home/Index/';");
        response.Append("</script>");
        return Content(response.ToString());
    }
        
