    public void testMethod()
    {
        using (DataTable dt = new DataTable())
        {
            using (DataTable dv = new DataView(dt))
            {
            }
        }
    }
