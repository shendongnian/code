    SolidBrush blueBrush = new SolidBrush(Color.Blue); // same as brush above, but being consistent
    SolidBrush redBrush = new SolidBrush(Color.Red); 
    SolidBrush greenBrush = new SolidBrush(Color.Green);
    int vertexRadius = 1; // change this to make the vertices bigger
    surface.fillEllipse(redBrush, new Rectangle(100 - vertexRadius, 100 - vertexRadius, vertexRadius * 2, vertexRadius * 2));
    surface.fillEllipse(blueBrush, new Rectangle(75 - vertexRadius, 50 - vertexRadius, vertexRadius * 2, vertexRadius * 2));
    surface.fillEllipse(greenBrush, new Rectangle(50 - vertexRadius, 100 - vertexRadius, vertexRadius * 2, vertexRadius * 2));
