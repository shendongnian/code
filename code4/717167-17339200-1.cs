    protected void grdPagine_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    if (e.CommandName == "Delete")
                {
    int id = Convert.ToInt32(e.CommandArgument);
                int b = new PaginaService().delPagina(id);
                List<Pagina> pag = new PaginaService().mlistapagine();
                this.grdPagine.DataSource = pag;
                this.grdPagine.DataBind();
    
    }
    
    }
