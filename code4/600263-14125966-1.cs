    [TestCase(0,0)]
    [TestCase(90,90)]
    [TestCase(180,180)]
    [TestCase(270,-90)]
    public void GetAngleTest(int angle, int expected)
    {
        var matrix = new RotateTransform(angle).Value;
        var x = new Vector(1, 0);
        Vector rotated = Vector.Multiply(x, matrix);
        double angleBetween = Vector.AngleBetween(x, rotated);
        Assert.AreEqual(expected,(int)angleBetween);
    }
