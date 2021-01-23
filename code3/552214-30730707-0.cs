    var instance = new ClassToBeInitialized
            {
                alpha = "alpha", 
                bravo = ExternalService(0),
                charlie = ExternalService(1)
            };
    private static string ExternalService(int parameter)
        {
            if (parameter == 1)
            {
                throw new Exception("The external service crashed");
            }
            return "correctStringResult";
        }
