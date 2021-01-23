     Camera.Forward = Vector3.Lerp( Ship.Forward, Camera.Fordward, 0.05f);
     Camera.Forward.Normalize();
     Camera.Forward*=Camera.Distance;
     Camera.Target = Ship.Target;
     Camera.Source = Ship.Target - Camera.Forward;
     Camera.Position = Camera.Source + Camera.Elevation;
