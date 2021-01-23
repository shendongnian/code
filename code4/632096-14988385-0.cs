    void InitModels()
    {
        Scene.CoordinateSystem cs1 = new Scene.CoordinateSystem(world.Ground)
        {
            DrawSize = 1,
            Visible = false
        };
        Scene.CoordinateSystem cs2 = new Scene.CoordinateSystem(world.Ground, 0.6 * vec3.J)
        {
            DrawSize = 0.5,
            Orientation = rot3.RotateXDegrees(-15)
        };
        Scene.Cube cube = new Scene.Cube(cs1)
        {
            CubeSize = 0.5
        };
        cs2.AddPoint(new point3(vec3.O,1), Color.Firebrick, 15);
        var line = cs2.AddLine(new line3(-vec3.I, vec3.I), 20, Color.SlateGray, 2);
        line.SetPattern(0xFF0F, GeometryTest.Scene.Stripple.Scale2);
        cube.BindTexture(5, GeometryTest.Properties.Resources.julia, true);
        cube.AddText(3, "OpenTK 1.0", Color.DarkMagenta, 0.5f, 0.5f, 1.0f);
    }
