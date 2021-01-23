    public class TestModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Test()
        {
            TestModel model=new TestModel(){Name="Manas",Id=1};
            Type t = model.GetType();
            NameValueCollection nvc=new NameValueCollection();
            foreach (var p in t.GetProperties())
            {
                var name = p.Name;
                var value=p.GetValue(model,null).ToString();
                nvc.Add(name, value);
            }
           var result= ConstructQueryString(nvc);
           return result;
        }
        public string ConstructQueryString(NameValueCollection Params)
        {
            List<string> items = new List<string>();
            foreach (string name in Params)
                items.Add(String.Concat(name, "=", HttpUtility.UrlEncode(Params[name])));
            return string.Join("&", items.ToArray());
        }
    }
