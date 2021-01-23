    if (FileUpload1.HasFile)
            {
               
                fname = FileUpload1.FileName;
                spath = "~\Pre\IntraExtra\" + FileUpload1.FileName;
                fpath = Server.MapPath("Uploaded");
                fpath = fpath + @"\" + FileUpload1.FileName;            
                desc = TextBox2.Text;
                if (System.IO.File.Exists(fpath))
                {
                    Label1.Text = "File Name already exists!";
                    return;
                }
                else
                {
                    FileUpload1.SaveAs(fpath);
                }
           }
