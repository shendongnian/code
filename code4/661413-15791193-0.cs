        DataTable myDataTable;
        try
        {
            myDataTable = new DataTable();
        }
        catch (Exception exp)
        {
            //Handle Exception
        }
        finally
        {
            myDataTable.Dispose();
        }
