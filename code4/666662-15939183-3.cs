    var speed = new Vector2(0.1f, 0.1f);
    Vector2 uvOffset = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    //unset first
    GraphicsDevice.SetVertexBuffer(null);
    foreach (ModelMesh mesh in model.Meshes)
    {
        foreach (ModelMeshPart mp in mesh.MeshParts)
        {                    
            //copy array first to change it
            var newVertices = new VertexPositionNormalTexture[mp.VertexBuffer.VertexCount];
            mp.VertexBuffer.GetData<VertexPositionNormalTexture>(newVertices);
            //offset all texture coords
            for (int i = 0; i < newVertices.Length; ++i)
            {
                newVertices[i].TextureCoordinate += uvOffset;
            }
            //set data back into buffer
            mp.VertexBuffer.SetData<VertexPositionNormalTexture>(newVertices);
        }
    }
