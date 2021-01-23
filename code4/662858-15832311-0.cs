    protected void Button1_Click(object sender, EventArgs e)
            {
                string filename = fileUpload.PostedFile.FileName;
                string extsn = Path.GetExtension(filename);
                if (extsn.ToUpper() == ".JPEG" || extsn.ToUpper() == ".PNG" || extsn.ToUpper() == ".GIF")
                { 
                    
                }
            }
