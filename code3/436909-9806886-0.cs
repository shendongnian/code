    static void Main(string[] args)
    {
        var splitFieldnames = new string[] { "field1", "field2", "field3" };
        var splitDatatypeNames = new string[] { "datatype1", "string", "string" };
        var SplitControlNames = new string[] { "control1", "control2", "control3" };
        var splitControlTypeNames = new string[] { "combobox", "textbox", "textbox"};
        // this code can handle different sized arrays, but is based strictly
        // on the size of the splitFieldnames array as the base.
        var splitMerged = splitFieldnames.Select
            ((c, idx) =>
                new
                {
                    fieldName = c,
                    dataType = splitDatatypeNames.Length > idx ? 
                        splitDatatypeNames[idx] : "",
                    controlName = SplitControlNames.Length > idx ? 
                        SplitControlNames[idx] : "",
                    controlTypeName = splitControlTypeNames.Length > idx?
                        splitControlTypeNames[idx] : "",
                });
       foreach (var item in splitMerged
          .Where(c => c.controlTypeName == "textbox" && c.dataType == "string"))
       {
           Console.WriteLine("_Student." + item.fieldName + "= " 
               + item.controlName + ".Text;");
       }
       Console.ReadKey();
