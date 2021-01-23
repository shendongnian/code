    public class MyObject
    {
        public string FieldId      { get; set; }
        public string FieldValue { get; set; }
    }
    List<MyObject> list = new List<MyObject> {
        new a  { FieldId = "0_Name", FieldValue = "test0"},
        new a  { FieldId = "1_Name", FieldValue = "test1" },
        new a  { FieldId = "2_Name", FieldValue = "test2" }
    };
    var pairs = from row in list
                where !row.FieldId.StartsWith("0_")
                && (row.FieldId.StartsWith("1_") ||
                    row.FieldId.StartsWith("2_"))
                select new
                {
                    key = row.FieldId,
                    value = row.FieldValue
                };
