      public interface IBase {
        string CommonMember { get; set; }
      }
    
      public interface IDerived : IBase {
        void DoSomething();
      }
     
      //IComplexDerived isnow a IDerived	
      public interface IComplexDerived : IDerived { 
        IEnumerable<object> Junk { get; }
      }
    
    public class Foo 
    {
      // Bar requires IEnumerable<IDerived> so you can't call it with a collection
      // of classes implementing IBase
      public void Bar( IEnumerable<IDerived> instances ) {
        foreach( IDerived instance in instances ) {
    		instance.DoSomething(); // DoSomething will "do something else" in 
    		                        // classes implementing IComplexDerived
        }
      }
    }
