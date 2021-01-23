    public static int createPrism(Dictionary<string, int> parameters){
        if(!parameters.ContainsKey("width"))
            Console.WriteLine("Missing parameter 'width'");
        if(!parameters.ContainsKey("height"))
            Console.WriteLine("Missing parameter 'height'");
        ...
        return length*width*height;
    }
