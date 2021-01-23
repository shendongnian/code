    public class Parent
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Child> Childrens { get; set; }
        }
    
        public class Child
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Item> Items { get; set; }
        }
        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        internal class Program
        {
            private class ADSetupInformation
            {
                public static void Main()
                {
    
                    var element =
                        XElement.Parse(
                            @"<Root RegisterVersion='1.0' xmlns='http://www.test.com.au/docs/schemas' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:schemaLocation='http://www.test.com/docs/schemas/spin/surcharge http://www.test.com/docs/schemas/test.xsd'>
                                <Parent id='1' name='parent1'>
                                    <Child id='1' name='child1'>
                                        <Item id='1' name='someitem'></Item>
                                    </Child>
                                </Parent>
                                <Parent id='2' name='parent2'>
                                    <Child id='2' name='child2'>
                                        <Item id='2' name='someotheritem'></Item>
                                    </Child>
                                </Parent>
                                </Root>
                                ");
    
                    XNamespace ns = element.Name.Namespace;
    
                    
    var list =
                        element.Elements(ns + "Parent")
                            .Select(compileItem => new Parent
                                                       {
                                                           Id = Convert.ToInt32(compileItem.Attribute("id").Value),
                                                           Name = compileItem.Attribute("name").Value,
                                                           Childrens = compileItem.Elements(ns + "Child")
                                                               .Select(child => new Child
                                                                                    {
                                                                                        Id = Convert.ToInt32(child.Attribute("id").Value),
                                                                                        Name = child.Attribute("name").Value,
                                                                                        Items = child.Elements(ns + "Item")
                                                                                            .Select(xe => new Item()
                                                                                                              {
                                                                                                                  Id = Convert.ToInt32(xe.Attribute("id").Value),
                                                                                                                  Name = xe.Attribute("name").Value,
                                                                                                              }).ToList()
                                                                                    }).ToList()                             
                                                       });
