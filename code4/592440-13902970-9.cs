    foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
    {
        pass.Apply();
        GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
            PrimitiveType.LineList,
            pointList,
            0,
            pointList.Length,
            lineListIndices,
            0,
            pointList.Length - 1
        );
    }
