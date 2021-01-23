    public class MyClass
    {
        public string SomeImportantField { get; set; }
        public string SomeOtherField { get; set; }
        public string AnotherField { get; set; }
    }
    public IList<MyClass> GetObjectsFromStream(Stream stream)
    {
        var cb = new DelimitedClassBuilder("temp", ",") { IgnoreFirstLines = 1, IgnoreEmptyLines = true, Delimiter = "," };
        var sr = new StreamReader(stream);
        var headerArray = sr.ReadLine().Split(',');
        foreach (var header in headerArray)
        {
            var fieldName = header.Replace("\"", "").Replace(" ", "");
            cb.AddField(fieldName, typeof(string));
        }
        var engine = new FileHelperEngine(cb.CreateRecordClass());
        List<MyClass> objects = new List<MyClass>();
        DataTable dt = engine.ReadStreamAsDT(sr);
        foreach (DataRow row in dt.Rows) // Loop over the rows.
        {
            MyClass myClass = new MyClass();
            for (int i = 0; i < row.ItemArray.Length; i++) // Loop over the items.
            {
                if (headerArray[i] == "ImportantField")
                    myClass.SomeImportantField = row.ItemArray[i].ToString();
                if (headerArray[i] == "OtherField")
                    myClass.SomeOtherField = row.ItemArray[i].ToString();
                if (headerArray[i] == "AnotherField")
                    myClass.AnotherField = row.ItemArray[i].ToString();
                objects.Add(myClass);
            }
        }
        return objects;
    }
