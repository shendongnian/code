    class Foo
    {
     //constructor
     public Foo()
     {
        PropertyChanged += (s,args) =>
        {
           switch(args.PropertyName)
           {
              case "Property" :
                Task.Factory.StartNew(() => { StaticBigFoo.Update();});
                break;
             ....
     public int Property
     { get ...
     {
       set  
       {
          if(_property == value) return;
          _property = value;
          RaisePropertyChanged(() => Property);
        ......
