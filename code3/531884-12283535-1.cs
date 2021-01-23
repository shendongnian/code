    protected void Page_Load(object sender, EventArgs e)
    {
       if(Session["YouObject"] != null)
       { 
         ClPersona obj = (ClPersona )Session["YouObject"];
         lblNombreUsuario.Text = string.Format("{0}-{1}", obj.FirstName, obj.LastName ) 
    
         
       }
          lblNombreUsuario.Text = (string)Session["sesionicontrol"];
         ....
    }
