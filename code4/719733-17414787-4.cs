    public static int createPrism(dynamic parameters){
        if(parameters.GetType().GetProperty("width") == null)
            Console.WriteLine("Invalid parameter 'width'");
        if(parameters.GetType().GetProperty("height") == null)
            Console.WriteLine("Invalid parameter 'height'");
        ...
        return parameters.length * parameters.width * parameters.height;
    }
