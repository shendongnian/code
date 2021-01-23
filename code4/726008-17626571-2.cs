    for (int i = 0; i < Request.Files.Count; i++)
            {           
               string strname = HdFirst1.Value;
               string[] txtval = strname.Split('~');
                HttpPostedFile PostedFile = Request.Files[i];
                if (PostedFile.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                   // string textname=
                    //PostedFile.SaveAs(Server.MapPath("Files\\") + FileName);
                }
            }
