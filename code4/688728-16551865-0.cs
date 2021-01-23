    class ArrayHolder { public static double[] Value; } //global state
    //set the global state somewhere else in your code:
    var size = DetermineSize();
    double[] array = new double[size];
    ArrayHolder.Value = array; //publish globally
