    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (MemoryStream memory = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(memory))
            {
                writer.WriteLine("hello, world");
                writer.Flush();
                Response.BinaryWrite(memory.ToArray());
            }
            Response.AddHeader("Content-Disposition", "Attachment; filename=helloworld.txt");
            Response.AddHeader("Content-Type", "application/octet-stream");
            Response.End();
        }
    }
