    string jsonstring = "{\"class\":\"Calculator\",\"method\":\"add\",\"parameters\": { \"x\" : \"12\", \"y\" : \"43\" }}";
    var json = (JObject)JsonConvert.DeserializeObject(jsonstring);
    Type type = Assembly.GetExecutingAssembly().GetTypes().First(x=>x.Name==(string)json["class"]);
    object inst = Activator.CreateInstance(type);
    var method =  type.GetMethod((string)json["method"]);
    var parameters = method.GetParameters()
            .Select(x => Convert.ChangeType((string)json["parameters"][x.Name], x.ParameterType))
            .ToArray();
    var result =  method.Invoke(inst, parameters);
-
    class Calculator
    {
        public int add(int x, int y)
        {
            return x + y;
        }
    }
