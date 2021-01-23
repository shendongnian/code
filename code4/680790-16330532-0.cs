    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e) {
    
           if(!Page.IsPostback)
          {
            string splitval = ListBox1.SelectedValue.ToString();
            string[] newvar = splitval.Split(',');
            GlobalVariables.attachcrq = newvar[0];
            GlobalVariables.num = UInt32.Parse(newvar[1]);
            string filename = ListBox1.SelectedItem.ToString();
            GlobalVariables.ARSServer.GetEntryBLOB("CHG:WorkLog", GlobalVariables.attachcrq, GlobalVariables.num, Server.MapPath("~/TEMP/") + filename);
    
            FileInfo file = new FileInfo(Server.MapPath("~/TEMP/" + filename));
            Response.Clear();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AppendHeader("Content-Length", file.Length.ToString());
            Response.ContentType = ReturnExtension(file.Extension.ToLower());
            Response.TransmitFile(file.FullName);
            Response.Flush();
            Response.End();
          }
        }
