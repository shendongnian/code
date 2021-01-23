    public class Foo : Bar
    {
       public IWhatever Whatever
       {
          get;
          private set;
       }
    
       public IFine Fine
       {
          get;
          private set;
       }
    
       public Foo(IWhatever whatever, IFine fine)
       {
          Whatever = whatever;
          Fine = fine;
       }
    }
