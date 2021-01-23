    //this is how you will create the Session on master page 
    {
       Session["text"] = txtearch.Text;
       Session["Text2"] = txtSearch2.Text;
       Session["Text3"] = txtSearch3.Text;
    }
    on another page just use it like
    {
       string a = Session["text"].ToString();
       string b = Session["text2"].ToString();
       string c = Session["text3"].ToString();
    }
