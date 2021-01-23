    double originalNumber = 6.3d;
    double integralPart = Math.Truncate(originalNumber); // this is now 6.0
    double fraction = originalNumber - integralPart; // this is now 0.3
    List<double> results = new List<double>();
    for (int i = 0; i <= integralPart; i++)
    {
        double newNumber = i + fraction;
        results.Add(newNumber);
    }
