    protected override void OnLoad(System.EventArgs e)
    {
        base.OnLoad(e);
        CargarMarcas();
        if (oAuto != null)
        {
            this.txtDominio.Text = oAuto.Dominio;
            SeleccionarMarca(oAuto.Marca);
        }
    }
