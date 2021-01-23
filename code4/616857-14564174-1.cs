    [Test]
    public void MoveForwardTest()
    {
        var position = new Point(0, 0);
        var direction = new Vector(1, 0);
        double distance = 5;
        //Update position moving forward distance along direction
        position = position + distance * direction; 
        Assert.AreEqual(5.0, position.X, 1e-3);
        Assert.AreEqual(0, position.Y, 1e-3);
    }
    [Test]
    public void RotateThenMoveTest()
    {
        var position = new Point(0, 0);
        var direction = new Vector(1, 0);
        double distance = 5;
        //Create the rotation matrix
        var rotateTransform = new RotateTransform(90); 
        //Apply the rotation to the direction
        direction = Vector.Multiply(direction, rotateTransform.Value); 
        //Update position moving forward distance along direction
        position = position + distance * direction; 
        Assert.AreEqual(0, position.X, 1e-3);
        Assert.AreEqual(5.0, position.Y, 1e-3);
    }
    
    [Test]
    public void CheckIfOtherCarIsInfrontTest()
    {
        var position = new Point(0, 0);
        var direction = new Vector(1, 0);
        var otherCarPosition = new Point(1, 0);
        //Create a vector from current car to other car
        Vector vectorTo = Point.Subtract(otherCarPosition, position); 
        //If the dotproduct is > 0 the other car is in front
        Assert.IsTrue(Vector.Multiply(direction, vectorTo) > 0); 
    }
