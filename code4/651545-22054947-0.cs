    public class SaveResponsePlugin : WebTestRequestPlugin
    {
        [DisplayName("File Name")]
        [Description("Name of file in which to save the response")]
        public string FileName { get; set; }
        public override void PostRequest(object sender, PostRequestEventArgs e)
        {
            if (e.ResponseExists && !e.Response.IsBodyEmpty)
                File.WriteAllBytes(this.FileName, e.Response.BodyBytes);
        }
    }
