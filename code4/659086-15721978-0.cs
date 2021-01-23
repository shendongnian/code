    class Root
    {
        public Dictionary<int, Category> data;
    }
    var o = JavaScriptSerializer.Deserialize<Root>(json);
