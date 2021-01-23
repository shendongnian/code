    public class SomeComplexViewModel
    {
      
        public SomeModel Model {get;set;}
    
        public string SomeCrazyProperty
        {
           get
           {
              return Model.SomeCrazyProperty;
           }
           {
              Model.SomeCrazyProperty = value;
              //... Some crazy logic here, potentially modifying some other properties as well.
           }
        }
    }
    <TextBox Text="{Binding SomeCrazyProperty}"/>
    
