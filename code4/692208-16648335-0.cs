    public void testMethod()
    {
        DataTable dt = new DataTable();
        DataView dv;
        try
        {
            dv = new DataView(dt);
        }
        finally
        {
            if (dt != null) dt.Dispose();
            if (dv != null) dv.Dispose();
        }
    }
