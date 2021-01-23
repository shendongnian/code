    // using System.Reflection required
    
    // first load the external assembly into the appdomain and 
    // create an instance of the object
    var assembly = Assembly.Load("Path to the Assembly");
    var type = assembley.GetType("TheNameOfTheClass");
    var ctor = type.GetConstuctor();
    var object = ctor.Invoke(); // assuming an empty construtor, else you'll need to pass in data
    
    // next invoke the method
    var methodInfo = assembly.GetMethodByName("ComputeMeanPosition");
    var param = new SortedList<DateTime, double>();
    var result = methodInfo.Invoke(object, new object[] { param });
