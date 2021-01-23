    static void INPCImplementation()
            {
                Console.WriteLine("INPC implementation and usage");
    
                var inpc = ObjectFactory.Create<INPCTester>(ParamList.Empty);
    
                Console.WriteLine("The resulting object is castable as INPC: " + (inpc is INotifyPropertyChanged));
    
                ((INotifyPropertyChanged)inpc).PropertyChanged += inpc_PropertyChanged;
    
                inpc.Name = "New name!";
                ((INotifyPropertyChanged)inpc).PropertyChanged -= inpc_PropertyChanged;
                Console.WriteLine();
            }
    static void inpc_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine("Hello, world! Property's name: " + e.PropertyName);
            }
    //OUTPUT:
    //INPC implementation and usage
    //The resulting object is castable as INPC: True
    //Hello, world! Property's name: Name
