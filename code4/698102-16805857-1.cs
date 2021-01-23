    string fileName = root.GetElementsByTagName("FLD_DOC_ID")[0].InnerText;
    fileName = fileName.Replace("..", "~");
    if (File.Exists(Server.MapPath(fileName))
    {
        // you probably do not want MapPath here:
        //proof.HRef = Server.MapPath(root.GetElementsByTagName("FLD_DOC_ID")[0].InnerText);
        proof.HRef = System.Web.VirtualPathUtility.ToAbsolute(fileName);
    }
