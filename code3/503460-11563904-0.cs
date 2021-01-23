    object arg = "foo";
    
    // Program.showThing(Thing t)
    var showThingReflected = GetType().GetMethod("showThing");
    
    // typeof(Thing)
    var paramType = showThingReflected.GetParameters()
                                      .Single()
                                      .ParameterType; 
                
    // Thing.implicit operator Thing(string s)
    var converter = paramType.GetMethod("op_Implicit", new[] { arg.GetType() });
    
    if (converter != null)
        arg = converter.Invoke(null, new[] { arg }); // Converter exists: arg = (Thing)"foo";
    
    // showThing(arg)
    showThingReflected.Invoke(this, new[] { arg });
