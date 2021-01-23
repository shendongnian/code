    public class ScopeObject
    { }
    
    public static class ProcessingScope
    {
      public static ScopeObject Current {get; set;}
    }
    
    using Xunit;
    public class NinjectCustomScopeExample
    {
      public class TestService { }
    
      [Fact]
      public static void Test()
      {
        var kernel = new StandardKernel();
        kernel.Bind<ScopeObject>().ToSelf().InScope( x => ProcessingScope.Current );
        
        var scopeA = new ScopeObject();
        var scopeB = new ScopeObject();
       
        ProcessingScope.Current = scopeA;
        var testA1 = kernel.Get<ScopeObject>();
        var testA2 = kernel.Get<ScopeObject>();
        
        Assert.Same( testA2, testA1 );
       
        ProcessingScope.Current = scopeB;
        var testB = kernel.Get<ScopeObject>();
        
        Assert.NotSame( testB, testA1 );
       
        ProcessingScope.Current = scopeA;
        var testA3 = kernel.Get<ScopeObject>();
        
        Assert.Same( testA3, testA1 );
      }
    }
