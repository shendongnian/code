    public class FeatureObject
    {
        public String Name { get; private set; }
        public Dictionary<String,String> Features { get; private set; }
    
    
        public FeatureObject (string name)
        {
            Name = name;
            Features = new Dictionary<String, String>();
            Features.Add("Name",name);//just an example of a feature that all objects have
        }
    }
    
    public class Fish: FeatureObject
    {
        public Color Color { get; private set; }
    
        public Fish(String name, Color color)
        :base(name) //initializes Name and Features as described in FeatureObject-class
        {
            Features.Add("Color", color.ToString());//Adds color to the features-dictionary
        }
    }
