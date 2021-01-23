    public abstract class BaseBuildable : MarshalByRefObject {
       public String Foo { get; internal set; }
    }
    
    public class DerivedBuildable : BaseBuildable { }
    
    public class BuildableBuilder : MarshalByRefObject {
       private String _foo;
       public BuildableBuilder WithFoo(String foo) { _foo = foo; return this; }
       public TBuildable Build<TBuildable>() where TBuildable : BaseBuildable, new() {
           return new TBuildable { Foo = _foo; }
       }
    }
    // Used so:
    var builder = domain.CreateInstanceAndUnwrap(.. // yadda yadda, you want a BuildableBuilder
    var buildable = builder.WithFoo("Foo, yo").Build();
