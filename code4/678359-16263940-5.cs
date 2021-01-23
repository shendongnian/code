    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 intId = 0;
            ImageButton btn = (sender as ImageButton)
            if(btn != null)
            {
                Int64 tempId;
                if(Int64.TryParse(btn.CommandArgument, out tempId))
                {
                    intId = intId;
                    /*Other part of the code*/
                }
            }
        }
        catch(Exception)
        {
            /*Other part of the code*/
        }
    }
