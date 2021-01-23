    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 intId = 0;
            String strRutaCompleta = String.Empty;
            ImageButton btn = (sender as ImageButton)
            if(btn != null)
            {
                int rowIndex;
                if(Int32.TryParse(btn.CommandArgument, out rowIndex))
                {
                    //not sure where you're data is coming from... using gvDataSource and assuming it's an IList.
                    var rowDataItem = gvDataSource[rowIndex];
                    intId = rowDataItem.Id;
                    strRutaCompleta = rowDataItem.RutaCompleta;
                    /*Other part of the code*/
                }
            }
        }
        catch(Exception)
        {
            /*Other part of the code*/
        }
    }
