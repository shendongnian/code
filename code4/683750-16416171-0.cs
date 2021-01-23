    private int tst = 0;
            protected void Page_Load(object sender, EventArgs e)
            {
                try
                {
                    tst = tst / tst; //causes "Attempted to divide by zero."
                    tst = 1;
                }
                catch (Exception ex) {
                    throw ex;
                }
            }
            protected void Page_Unload(object sender, EventArgs e)
            {
                if (tst == 0) throw new Exception("Exception on unload");
            }
