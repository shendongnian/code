    lblNombreUsuario.Text = (string)Session["sesionicontrol"];
    if (!IsPostBack)
    {
        //prueba 
        if (Request.QueryString.Count > 0)
        {
            if Request.QueryString["rut"] != null)
            {
                txtRutEncuestador.Text = Request.QueryString["rut"].ToString();
                leerNombre();
            }
            
            if (Request.QueryString["cod_sap"] != null)
            {
                txtIdEstudio.Text = Request.QueryString["cod_sap"].ToString();
                leerEstudios();
            }
        } 
    }
