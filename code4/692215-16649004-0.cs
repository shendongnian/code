    public void testMethod()
    {
        DataTable dt = null;
        DataView dv = null;
        try
        {
            dt = new DataTable();
            dv = new DataView(dt);
        }
        catch
        {
        }
        finally
        {
            if (dt != null) dt.Dispose();
            if (dv != null) dv.Dispose();
        }
    }
