    string jsonstring = "{\"class\":\"Calculator\",\"method\":\"add\",\"parameters\": { \"x\" : \"12\", \"y\" : \"43\" }}";
    var json = (JObject)JsonConvert.DeserializeObject(jsonstring);
    Type type = Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .First(t => t.Name==(string)json["class"]);
    object inst = Activator.CreateInstance(type);
    var method =  type.GetMethod((string)json["method"]);
    var parameters = method.GetParameters()
            .Select(p => Convert.ChangeType((string)json["parameters"][p.Name], p.ParameterType))
            .ToArray();
    var result =  method.Invoke(inst, parameters);
    var toReturn = JsonConvert.SerializeObject(new {status="OK",result=result });
-
    class Calculator
    {
        public int add(int x, int y)
        {
            return x + y;
        }
    }
