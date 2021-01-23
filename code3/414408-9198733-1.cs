    protected void grdImovei_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
           var url = "../Financeiro/DetalheImovelProposta.aspx?Imovel_Id=" +
                     ((SomeType)r.Row.DataItem).Imovel_id.ToString();
           e.Row.Attributes.Add("onclick", "openPopup('" + url + "'," +
               @"'Detalhes', 
               'toolbar=yes,directories=no,status=yes,menubar=yes,
               scrollbars=yes,resizable=yes', '850', '600', 'true');");
        }
    }
