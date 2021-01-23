    List<string> validExtensions = new List<string> {".jpg", ".jpeg", ".png" };
    if (validExtensions.Contains(sFileExt1.ToLower()))
    {
        hpf.SaveAs(Server.MapPath("Special_Requests\\") + Path.GetFileName(hpf.FileName));
        iUploadedCnt += 1;
        lblMsg.Text = "File(s) upload successfully.";        
    }
    else
    {
        //lblMsg.Text = "Extension not supported";
        lblMsg.Text = sFileExt1;
        break;
    }
