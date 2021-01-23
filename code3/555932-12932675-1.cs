    public class ComponentTests{
      [Fact]
      public void MethodADoesSomething(){
        Assert.xxx(new Component().MethodA());//Tests the component class
      }
    
      [Fact]
      public void MethodBDoesSomething(){
        Assert.xxx(new Component().MethodB());//Tests the component class
      }
    }
    
    public class ExtendedComponentTests{
      [Fact]
      public void MethodADoesSomething(){
        Assert.xxx(new ExtendedComponent().MethodA());//Tests the extended component class
      }
    }
