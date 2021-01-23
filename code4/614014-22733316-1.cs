    public void printMB(uint sizekB)   
    {
        double sizeMB = (double) sizekB / 1024;
        Console.WriteLine("Size is " + sizeMB.ToString("0.00") + "MB");
    }
