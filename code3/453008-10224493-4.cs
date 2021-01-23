    public void btnEdit_Click(object sender, EventArgs e)
    {
        if(myXmlDocument != null && GrabComic != null && GrabComic.ChildNodes.Count >3){
            GrabComic.ChildNodes[0].InnerText = txtTitle.Text; 
            GrabComic.ChildNodes[1].InnerText = txtIssue.Text;
            GrabComic.ChildNodes[2].InnerText = txtDesc.Text;
            myXmlDocument.Save(Path.Combine(Request.PhysicalApplicationPath, "comic.xml"));
    
            lblMessage.Text = "You have successfully updated the Database";
        }
    }
