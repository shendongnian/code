    <#@ template language="C#" #>
    <#@ import namespace="System.Collections" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#+
    class Activity : IEnumerable<Property>
    {
        private string name, wrapper;
        private List<Property> properties;
        public Activity(string name, string wrapper = null)
        {
            this.name = name;
            this.wrapper = wrapper ?? name + "Wrapper";
            this.properties = new List<Property>();
        }
        public void Add(Property property)
        {
            this.properties.Add(property);
        }
        public IEnumerator<Property> GetEnumerator()
        {
            return this.properties.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void GenerateCode()
        {
            // ...
        }
    }
    class Property
    {
        private bool output;
        private string name, type;
        public Property(bool output, string name, string type)
        {
            this.output = output;
            this.name = name;
            this.type = type;
        }
    }
    Property Input(string name, string type = "string")
    {
        return new Property(false, name, type);
    }
    Property Output(string name, string type = "string")
    {
        return new Property(true, name, type);
    }
    void GenerateCode(params Activity[] activities)
    {
        WriteLine("namespace Foo");
        WriteLine("{");
        PushIndent("   ");
        foreach (var activity in activities)
        {
            WriteLine("class " + activity.name);
            WriteLine("{");
            PushIndent("   ");
            // ...
            PopIndent();
            WriteLine("}");
        }
        PopIndent();
        WriteLine("}");
    }
    #>
