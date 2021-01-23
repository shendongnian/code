    public abstract class AbstractParameter
    {
        public string Name       { get ; protected set ; }
        public bool   IsRequired { get ; protected set ; }
        public int    ID         { get ; protected set ; }
        protected AbstractParameter( string name , bool isRequired , int id )
        {
            this.Name       = name;
            this.IsRequired = isRequired;
            this.ID         = id;
            this.Value      = default(T) ;
            return;
        }
        
        public abstract AbstractParameter CreateInstance( string xml ) ;
        
    }
