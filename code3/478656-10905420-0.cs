        class Program
       {
        private CompositionContainer _container;       
    
        private Program()
        {
            var helper = new MyOtherHelperClass();
            var catalog = helper.CreateCatalog();
    
            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);
    
            //Fill the imports of some object
            try
            {
                var thingIWantToCompose = new OtherClassWithAnImport();
                this._container.ComposeParts(thingIWantToCompose);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
    
    
        static void Main(string[] args)
        {
            Program p = new Program(); //Composition is performed in the constructor
        }
    }
