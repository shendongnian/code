    Dictionary<string, FileUpload> DocsPathAndControl = new Dictionary<string, FileUpload>();
    if (Session["AttachFilesdt"] != null)
            {
                tempdt = (DataTable)Session["AttachFilesdt"];
                for (int i = 0; i < tempdt.Rows.Count; i++)
                {
                    DocsPathAndControl.Add(tempdt.Rows[i]["Path"].ToString(), (FileUpload)tempdt.Rows[i]["Control"]);
                }
                Session["AttachFilesdt"] = null;
            }
