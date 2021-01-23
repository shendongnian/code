    var basicEffect = new BasicEffect( game.GraphicsDevice );
    basicEffect.EnableDefaultLighting();
    foreach (var mesh in _modelHead.Meshes)
        foreach (var part in mesh.MeshParts)
            part.Effect = basicEffect;
