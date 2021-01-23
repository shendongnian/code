       public  class TestClass {
            public string String1 { get; set; }
            public string String2 { get; set; }
            public int Int1 { get; set; }
            public TestClass() {
                String1 = "Frank";
                String2 = "Borland";
                foreach (var item in this.GetType().GetProperties().Where(p => p.PropertyType.Equals(typeof(string)))) {
                    string value = item.GetValue(this, null) as string;
                    Debug.WriteLine("String: {0} Value: {1}", item.Name, value);
                }
            }
        }
