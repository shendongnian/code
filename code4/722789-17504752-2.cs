    protected void Page_Load(object sender, EventArgs e)
            {
                   Response.Clear();
                   byte[] a = Common.GetImage();
                   Response.BinaryWrite(a);
                   Response.End();
            }
