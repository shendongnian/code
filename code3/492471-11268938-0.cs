    protected void btnLogin_Click(object sender, EventArgs e)
    {
        ClUsuario login = new ClUsuario();
        bool isAuthenticated = login.sqlLogin(txtUsuario.Text, txtPass.Text);
        if (isAuthenticated)
        {
            Response.Redirect("/Inicio.aspx");
        }
        else    
        {
            lblMsg.Text = "usuario/password no validos";
        }
    }
    
    
    And return bool in your sqlLogin
    
    try with this code 
    
    if(dt.Rows.Count > 0)
    {
       return true;
    } 
    return false;
