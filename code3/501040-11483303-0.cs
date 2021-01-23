    using System.Linq;
    
    foreach (CObject value in ExampleDictionary.Values.ToArray()) {
       this.SendConsoleMessage(value.SomeVariableInObject);
    }
