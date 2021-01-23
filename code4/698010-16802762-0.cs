    using ImpromptuInterface;
    
    public interface ISimpleClassProps
    {
      string Prop1 { get;  }
      long Prop2 { get; }
      Guid Prop3 { get; }
    }
    
    var tAnon = new {Prop1 = "Test", Prop2 = 42L, Prop3 = Guid.NewGuid()};
    var tActsLike = tAnon.ActLike<ISimpleClassProps>();
