    protected void Page_Load(object sender, EventArgs e)
    {
        using (var reader = new StreamReader(Request.InputStream))
        {
            string json = reader.ReadToEnd();
            var serializer = new JavaScriptSerializer();
            MyModel model = serializer.Deserialize<MyModel>(json);
            // you could use the model here
        }
    }
