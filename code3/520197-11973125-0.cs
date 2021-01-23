    protected void dpdListEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);   
        MeaningfulNameHere(int.Parse(grdvEventosVendedor.DataKeys[gvr.RowIndex]));
    }
    protected void grdvEventosVendedor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        MeaningfulNameHere(int.Parse(e.CommandArgument.ToString()));
    }
    private void MeaningfulNameHere(int id)
    {
        if (e.CommandName == "Edicion")
        {
            //Some Code
        }
        else if (e.CommandName == "Borrar")
        {
           //More Code
        }
        else if (e.CommandName == "CRM")
        {
            //Even More Code
        }
        else if (e.CommandName == "VerMas")
        {
            //....
        }
    }
