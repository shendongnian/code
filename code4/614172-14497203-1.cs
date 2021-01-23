    public void RenderFrame(Model[] models)
    {
        // Per frame
        Bind(View);
        Bind(Projection);
        BindLighting();
        // Per effect
        BindEffect();
        foreach (var material in GetMaterials(models))
        {
            // Per material
            Bind(material.Color);
            Bind(material.DiffuseMap);
            foreach (var model in GetModelsByMaterial(material, models))
            {
                // Per mesh
                Bind(model.VertexBuffer);
                Bind(model.IndexBuffer);
                foreach (var instance in model.Instances)
                {
                    // Per instance
                    Bind(instance.World);
                    // Draw the instance
                    Draw();
                }
            }
        }
    }
