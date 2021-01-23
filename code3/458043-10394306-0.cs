    public class Config
    {
       public string Name { get; set; }
       public int Foo { get; set; }
       public IList<Element> Elements { get; private set; }
       public Config()
       {
           Elements = new List<Element>();
       }
    }
    // I'm assuming an element *always* needs a name and a height
    class Element
    {
       public string Name { get; private set; }
       public int Height { get; private set; }
       public Element(string name, int height)
       {
           this.Name = name;
           this.Height = height;
       }
    }
