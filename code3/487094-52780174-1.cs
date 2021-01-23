     private static void Main(string[] args)
        {
            var dataList = new List<TestDataClass>
            {
                new TestDataClass {Name = "A", Lastname = "B", Other = "ABO"},
                new TestDataClass {Name = "C", Lastname = "D", Other = "CDO"},
                new TestDataClass {Name = "E", Lastname = "F", Other = "EFO"},
                new TestDataClass {Name = "G", Lastname = "H", Other = "GHO"}
            };
            var headerList = new List<string> { "Name", "Surname", "Merge" };
            var customTableStyle = new List<EnumerableExtension.CustomTableStyle>
            {
                new EnumerableExtension.CustomTableStyle{CustomTableStylePosition = EnumerableExtension.CustomTableStylePosition.Table, InlineStyleValueList = new Dictionary<string, string>{{"font-family", "Comic Sans MS" },{"font-size","15px"}}},
                new EnumerableExtension.CustomTableStyle{CustomTableStylePosition = EnumerableExtension.CustomTableStylePosition.Table, InlineStyleValueList = new Dictionary<string, string>{{"background-color", "yellow" }}},
                new EnumerableExtension.CustomTableStyle{CustomTableStylePosition = EnumerableExtension.CustomTableStylePosition.Tr, InlineStyleValueList =new Dictionary<string, string>{{"color","Blue"},{"font-size","10px"}}},
                new EnumerableExtension.CustomTableStyle{CustomTableStylePosition = EnumerableExtension.CustomTableStylePosition.Th,ClassNameList = new List<string>{"normal","underline"}},
                new EnumerableExtension.CustomTableStyle{CustomTableStylePosition = EnumerableExtension.CustomTableStylePosition.Th,InlineStyleValueList =new Dictionary<string, string>{{ "background-color", "gray"}}},
                new EnumerableExtension.CustomTableStyle{CustomTableStylePosition = EnumerableExtension.CustomTableStylePosition.Td, InlineStyleValueList  =new Dictionary<string, string>{{"color","Red"},{"font-size","15px"}}},
            };
            var htmlResult = dataList.ToHtmlTable(headerList, customTableStyle, x => x.Name, x => x.Lastname, x => $"{x.Name} {x.Lastname}");
        }
        private class TestDataClass
        {
            public string Name { get; set; }
            public string Lastname { get; set; }
            public string Other { get; set; }
        }
