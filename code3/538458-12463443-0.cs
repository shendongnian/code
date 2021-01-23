    //Anonymous Class
    var anon = new {
             Prop1 = "Test",
             Prop2 = 42L,
             Prop3 = Guid.NewGuid(),
             Meth1 = Return<bool>.Arguments<int>(it => it > 5)
    }
    var myInterface = anon.ActLike<IMyInterface>();
