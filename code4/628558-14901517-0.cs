    class Program
    {
        const string file1 = @"<root><foo name=""1""><val1>hello</val1><val2>world</val2></foo><foo name=""2""><val1>bye</val1></foo></root>";
        const string file2 = @"<root><foo name=""1""><val2>friend</val2></foo></root>";
        static void Main(string[] args)
        {
            XDocument document1 = XDocument.Parse(file1);
            XDocument document2 = XDocument.Parse(file2);
            foreach (XElement foo in document2.Descendants("foo"))
            {
                foreach (XElement val in foo.Elements())
                {
                    XElement elementToUpdate = (from fooElement in document1.Descendants("foo")
                                                from valElement in fooElement.Elements()
                                                where fooElement.Attribute("name").Value == foo.Attribute("name").Value &&
                                                     valElement.Name == val.Name
                                                select valElement).FirstOrDefault();
                    if (elementToUpdate != null)
                        elementToUpdate.Value = val.Value;
                }
            }
            Console.WriteLine(document1.ToString());
            Console.ReadLine();
        }
    }
