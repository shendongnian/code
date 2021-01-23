WebForm1.aspx
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnDL').click(function () {
                $('body').append('<iframe src="WebForm2.aspx" style="display:none;"></iframe>');
                return true;
            });
        });
    </script>
    <asp:Button runat="server" ID="btnDL" ClientIDMode="Static" Text="Download" OnClick="btnDL_Click" />
WebForm1.aspx.cs
    protected void btnDL_Click(object sender, EventArgs e)
    {
        var sent = Session["sent"];
    
        while (Session["sent"]==null)
        {// not sure if this is a bad idea but my cpu is NOT going nuts
        }
    
        System.Threading.Thread.Sleep(5000);
    
        Response.Redirect("http://google.com");
    }
WebForm2.aspx.cs
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;  filename=test.pdf");
        Response.ContentType = "application/pdf";
        byte[] a = System.Text.Encoding.UTF8.GetBytes("test");
        Response.BinaryWrite(a);
        Session["sent"] = true;
    }
Global.asax.cs
    protected void Session_Start(object sender, EventArgs e)
    {
        Session["init"] = 0; // init and allocate session data storage
    }
