                    quinticFX.Parameters["NumPoints"].SetValue(CurvedVertices.Count());
                    //GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
                    GraphicsDevice.SamplerStates[0] = LinearMirrorState;
                    GraphicsDevice.Textures[0] = solid;
                    quinticFX.Parameters["radiusOfBeam"].SetValue(12);
                    pass.Apply();
                    GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleStrip, CurvedVertices.ToArray(), 0, CurvedVertices.Count() - 2);
                    quinticFX.Parameters["radiusOfBeam"].SetValue(6);
                    quinticFX.Parameters["P"].SetValue(cp1);
                    pass.Apply();
                    GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleStrip, CurvedVertices.ToArray(), 0, CurvedVertices.Count() - 2);
                    
                    quinticFX.Parameters["radiusOfBeam"].SetValue(3);
                    quinticFX.Parameters["P"].SetValue(cp2);
                    pass.Apply();
                    GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleStrip, CurvedVertices.ToArray(), 0, CurvedVertices.Count() - 2);
                }
