    protected void dpdListEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);   
        MeaningfulNameHere(int.Parse(grdvEventosVendedor.DataKeys[gvr.RowIndex]),"Estado");
    }
    protected void grdvEventosVendedor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        MeaningfulNameHere(int.Parse(e.CommandArgument.ToString()),e.CommandName);
    }
    private void MeaningfulNameHere(int id, string commandName)
    {
        if (commandName == "Edicion")
        {
            //Some Code
        }
        else if (commandName == "Borrar")
        {
           //More Code
        }
        else if (commandName == "CRM")
        {
            //Even More Code
        }
        else if (commandName == "VerMas")
        {
            //....
        }
        else if (commandName == "Estado")
        {
        }
    }
