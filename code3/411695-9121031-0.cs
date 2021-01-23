    public interface IMovable { void Move(); }
    
    public class MoveMixin : IMovable
    {
       public void Move() { Console.WriteLine("I am moving"); }
    }
    
    public class SomeDude { }
    
    public static class TestClass
    {
       public static Test()
       {
          var myMixinConfiguration = MixinConfiguration.BuildFromActive()
               .ForClass<SomeDude>().AddMixin<MoveMixin>()
               .BuildConfiguration();
          using(myMixinConfiguration.EnterScope())
          {//In this scope, SomeDude implements IMovable, but only if you get an instance through the ObjectFactory
             var myMovableDude = ObjectFactory.Create<SomeDude>(ParamList.Empty);
             ((IMovable)myMovableDude).Move(); //This line compiles and executes just fine, even though the class declaration does not specify anything about Move() !!
          }
          //The SomeDude class no longer implements IMovable
       }
    }
