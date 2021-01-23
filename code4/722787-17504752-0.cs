    protected void Page_Load(object sender, EventArgs e)
            {
                   byte[] a = Common.GetImage();
                   Response.BinaryWrite(a);
            }
