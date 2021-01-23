        string Name = txtname.Text;
       string contents = File.ReadAllText(Server.MapPath("~/Admin/invoice.html"));
                StringBuilder builder = new StringBuilder(contents);
                builder.Replace("[Name]", Name);
                StringReader sr = new StringReader(builder.ToString());
