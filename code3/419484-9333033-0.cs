        using ImpromptuInterface;
        using ImpromptuInterface.Dynamic;
    
        public interface IMyInterface{
    
           string Prop1 { get;  }
    
            long Prop2 { get; }
    
            Guid Prop3 { get; }
    
            bool Meth1(int x);
       }
    
       //Anonymous Class
        var anon = new {
                 Prop1 = "Test",
                 Prop2 = 42L,
                 Prop3 = Guid.NewGuid(),
                 Meth1 = Return<bool>.Arguments<int>(it => it > 5)
        }
    
        IMyInterface myInterface = anon.ActLike<IMyInterface>();
