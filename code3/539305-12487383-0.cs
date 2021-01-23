    public class Class1 {
        public Class1() {
            var foo = new Class2();
            var table = foo.MyTable();
            Method1(table.Rows[0]["Column1"], table.Rows[0]["Column2"]);
        }
    }
