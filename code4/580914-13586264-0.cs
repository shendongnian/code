    public class MyDependency : IMyDependency {
       Lazy<IMyOtherDepenency> _otherDependency;
       public MyDependency(Lazy<IMyOtherDependency> otherDependency){
          _otherDependency = otherDependency;
       }
       public void DoSomething(){
          //calling Value triggers Autofac to resolve the dependency...
          _otherDependency.Value.DoThings();
       }
    }
