    var model = ModelImporter.Load(gameAssetPath);
    var modelRotation = new Model3DGroup();
    modelRotation.Children.Add(model);
    var t1 = new TranslateTransform3D(
            placedObject.SpawnCoordinates.X,
            placedObject.SpawnCoordinates.Y,
            placedObject.SpawnCoordinates.Z);
    var t2 = new RotateTransform3D(
             new AxisAngleRotation3D(), 
            placedObject.SpawnCoordinates.Roll, 
            placedObject.SpawnCoordinates.Pitch, 
            placedObject.SpawnCoordinates.Yaw);
    var tg = new TransformGroup();
    tg.Children.Add(t1);
    tg.Children.Add(t2);
    modelRotation.Transform = tg;
