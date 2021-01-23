            device.DepthStencilState = DepthStencilState.Default;
            device.BlendState = BlendState.AlphaBlend;
            device.RasterizerState = RasterizerState.CullCounterClockwise;
            //Set the appropriate vertex and indice buffers
            device.SetVertexBuffer(_polygonVertices);
            device.Indices = _polygonIndices;
            foreach (EffectPass pass in _worldEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                PApp.Graphics.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, _polygonVertices.VertexCount, 0, _polygonIndices.IndexCount / 3);
            }
