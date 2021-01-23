    var numbers = new double[] { 3.42421, 265.6250, 812.50, 12.68798, 0.68787 };
    foreach (var number in numbers)
    {
    	Console.WriteLine(number.ToEngV(4, false));
    }
    Console.WriteLine()
    foreach (var number in numbers)
    {
    	Console.WriteLine(number.ToEngV(4, true));
    }
