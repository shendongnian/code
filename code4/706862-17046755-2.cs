    using ImpromptuInterface;
    using ImpromptuInterface.Dynamic;
    public interface IMyInterface
    {
       string Prop1 { get;  }
    }
    //Anonymous Class
    var anon = new {
             Prop1 = "Test",
    }
    var myInterface = anon.ActLike<IMyInterface>();
