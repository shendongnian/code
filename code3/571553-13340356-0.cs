    IEnumerator i = cars.GetEnumerator();
    while (i.MoveNext())
    {
        Car myCar = (Car)i.Current;
        Console.WriteLine("{0} is going {1} km/h", myCar.Name, myCar.CurrentSpeed);
    }
