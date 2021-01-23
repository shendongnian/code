    public static void ModelData(Model model)
    {
        ModelMeshPart part = model.Meshes[0].MeshParts[0];
    
        VertexPositionNormalTexture[] vertices = new VertexPositionNormalTexture[part.VertexBuffer.VertexCount];
        part.VertexBuffer.GetData<VertexPositionNormalTexture>(vertices);
    
        ushort[] drawOrder = new ushort[part.IndexBuffer.IndexCount];
        part.IndexBuffer.GetData<ushort>(drawOrder);
    
    }
