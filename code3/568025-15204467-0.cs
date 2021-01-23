    public RotateTransform3D MyRotationTransform { get; set; }
    ...
    //constructor
    public MyClass()
    {
         MyRotationTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0));
    }
    //in your method
    MyRotationTransform.Rotation += 15;
    objGeometryModel3D.Transform = MyRotationTransform;
