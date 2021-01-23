    foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
    {
        pass.Apply();
        GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
            PrimitiveType.LineList,
            pointListList,
            0, 
            pointListList.Length,  
            lineListIndicesList, 
            0,  
            pointListList.Length - 1
        );
    }
