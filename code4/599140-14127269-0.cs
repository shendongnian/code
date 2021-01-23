    // The center point of rotation
    var centerPoint = new Point(0, 0);
    // Factory method creating the matrix                                        
    var matrix = new RotateTransform(angleInDegrees, centerPoint.X, centerPoint.Y).Value;
    // The point to rotate
    var point = new Point(100, 0);
    // Applying the transform that results in a rotated point                                      
    Point rotated = Point.Multiply(point, matrix); 
 
