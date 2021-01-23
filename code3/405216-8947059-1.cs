    public class ConcreteParameter : AbstractParameter
    {
        public ConcreteParameter( string name , bool isRequired , int id ) : base( name , isRequired , id )
        {
            return ;
        }
        
        public override AbstractParameter CreateInstance( string xml )
        {
            string            name     = XmlParser.GetName();
            bool              required = XmlParser.GetIsRequired();
            int               id       = XmlParser.GetID();
            ConcreteParameter instance = new ConcreteParameter( name , required , id );
            
            return instance;
        }
        
    }
