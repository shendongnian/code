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
