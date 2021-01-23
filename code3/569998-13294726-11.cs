    class A: INotifyPropertyChanged
    {
       string PhoneNumber;
       string _name;
       B BoundItem = null;
       Public string Name {
         get { return _name;}
         set 
         { 
             _name = value; 
             if(BoundItem != null)
                  BoundItem.Name = value;
         }
    }
    
    class B
    {
       string Name;
       int age;
    }
    class Main
    {
         public Main()
         {
             A item = new A();
             B boundItem = new B();
             item.BoundItem = boundItem;
             item.Name = "TEST";
             Console.WriteLine("Item Name: " + item.Name);
             Console.WriteLine("BoundItem Name: " + boundItem.Name);
             // Result:
             // Item Name: TEST
             // BoundItem Name: TEST
         }
    }
