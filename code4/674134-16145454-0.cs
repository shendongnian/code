        try
        {
            ware.Insert();
        }
        catch(GeneralException ex)
        {
            MessageBox.Show(ex.Message);
        }
