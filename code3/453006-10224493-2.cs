    public void btnEdit_Click(object sender, EventArgs e)
    {
        GrabComic.ChildNodes[0].InnerText = txtTitle.Text;
        GrabComic.ChildNodes[1].InnerText = txtIssue.Text;
        GrabComic.ChildNodes[2].InnerText = txtDesc.Text;
        if(myXmlDocument != null){
            myXmlDocument.Save(Path.Combine(Request.PhysicalApplicationPath, "comic.xml"));
    
            lblMessage.Text = "You have successfully updated the Database";
        }
    }
