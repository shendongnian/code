    [Test]
    public void MoveForwardTest()
    {
        var position = new Point(0, 0);
        var direction = new Vector(1, 0);
        double distance = 5;
        position = position + distance * direction; //Update position moving forward distance along direction
        Assert.AreEqual(5.0, position.X, 1e-3);
        Assert.AreEqual(0, position.Y, 1e-3);
    }
    [Test]
    public void RotateThenMoveTest()
    {
        var position = new Point(0, 0);
        var direction = new Vector(1, 0);
        double distance = 5;
        var rotateTransform = new RotateTransform(90); //Create the rotation matrix
        direction = Vector.Multiply(direction, rotateTransform.Value); //Apply the rotation to the direction
        position = position + distance * direction; //Update position moving forward distance along direction
        Assert.AreEqual(0, position.X, 1e-3);
        Assert.AreEqual(5.0, position.Y, 1e-3);
    }
