    XElement root = XElement.Load(file); // or .Parse(string)
    List<Camera> cameras = root.GetEnumerable("Cameras/Camera", x => new Camera()
    {
        Make = x.Get("Make", string.Empty),
        Model = x.Get("Model", string.Empty),
        Variable1 = x.Get<double>("Variable1", 0),
        Variable2 = x.Get<double>("Variable2", 0)
    }).ToList();
