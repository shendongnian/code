    void Main()
    {
        var random = new Random();
        // "sea level"
        var baseDiameter = 10;
        // very chaotic heightmap
        heightmap = Enumerable
            .Range(0, 360)
            .Select(_ => random.NextDouble() * baseDiameter)
            .ToArray();
        
        // let's walk by half degrees, since that's roughly how many points we have
        for(double i=0;i<360;i+=0.5)
        {
            var angleInDegrees = i;
            var angleInRads = MathHelper.DegToRad(i);
            Console.WriteLine("Height at angle {0}°({1} rad):{2} (using getheight:{3})",
                angleInDegrees,
                angleInRads,
                heightmap[(int)angleInDegrees],
                getheight(angleInRads));
        }
    }
    
    double[] heightmap;
