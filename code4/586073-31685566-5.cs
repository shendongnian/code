    private void FillView(int desiredPage)
    {
        var cliente = ClientFactory.CreateAuthServiceClient();
        using (cliente as IDisposable)
        {
            // this list only has 1 item.
            List<TipoPresupuesto> resultado = cliente.ObtenerTiposDePresupuesto();
            gvPresupuestos.DataSource = resultado;
            // For testing pursposes, force the virtual item count to 1000.
            gvPresupuestos.VirtualItemCount = 1000;
            gvPresupuestos.DataBind();
        }
    }
