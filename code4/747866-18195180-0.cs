    void Main()
    {
    	XElement root = XElement.Parse(
    @"<Viewdata>
        <Format>{0} | {1}</Format>
        <Parm>Name</Parm>
        <Parm>Phone</Parm>
    </Viewdata>");
    
    	var formatter = root.Descendants("Format").FirstOrDefault().Value;
    	var parms = root.Descendants("Parm").Select(x => x.Value).ToArray();
    
    	Person person = new Person { Name = "Jack", Phone = "(123)456-7890" };
    
    	string formatted = MagicFormatter<Person>(person, formatter, parms);
    	formatted.Dump();
    /// OUTPUT ///
    /// Jack | (123)456-7890
    }
    
    public string MagicFormatter<T>(T theobj, string formatter, params string[] propertyNames)
    {
    	for (var index = 0; index < propertyNames.Length; index++)
    	{
    		PropertyInfo property = typeof(T).GetProperty(propertyNames[index]);
    		propertyNames[index] = (string)property.GetValue(theobj);
    	}
    
    	return string.Format(formatter, propertyNames);
    }
    
    public class Person
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
