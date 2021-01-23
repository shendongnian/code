    public class MyObject
    {
        public string FieldId      { get; set; }
        public string FieldValue { get; set; }
    }
    List<MyObject> list = new List<MyObject> {
        new MyObject { FieldId = "0_Name", FieldValue = "test0"},
        new MyObject { FieldId = "1_Name", FieldValue = "test1" },
        new MyObject { FieldId = "2_Name", FieldValue = "test2" }
    };
    var pairs = from row in list
                where !row.FieldId.StartsWith("0_")
                && row.FieldValue != "0.00")
                select new
                {
                    key = row.FieldId,
                    value = row.FieldValue
                };
