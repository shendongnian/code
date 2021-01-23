    var deg = 90.0;
    var rads = deg * (Math.PI / 180);
    var result = Math.Tan(rads);
    if (Double.IsInfinity(result))
        Console.WriteLine("Tan of 90 degrees is Infinity");
    else if (Double.IsNaN(result))
        Console.WriteLine("Tan of 90 degrees is Undefined");
    else
        Console.WriteLine("Tan of 90 degrees is {0}", result);
    Console.WriteLine("Arc Tan of {0} is {1} degrees", double.PositiveInfinity, Math.Atan(result) * 180 / Math.PI);
    Console.WriteLine("Arc Tan of {0} is {1} degrees", result, Math.Atan(result) * 180 / Math.PI);
