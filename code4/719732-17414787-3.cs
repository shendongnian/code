    public static int createPrism(Dictionary<string, int> parameters){
        if(!parameters.ContainsKey("width"))
            Console.WriteLine("Missing parameter 'width'");
        if(!parameters.ContainsKey("height"))
            Console.WriteLine("Missing parameter 'height'");
        ...
        return parameters["length"] * parameters["width"] * parameters["height"];
    }
