    public void SetModelEffect(Effect effect)
    {
      foreach (ModelMesh mesh in model.Meshes)
        foreach (ModelMeshPart part in mesh.MeshParts)
        {
          part.Effect = effect;
        }
    }
    
