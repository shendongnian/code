    private void draw_groundLand1()
        {
            for (int a = 0; a < 10; a++)
            {
                // Copy any parent transforms.
                Matrix[] transforms = new Matrix[model_ground_land1.Bones.Count];
                model_ground_land1.CopyAbsoluteBoneTransformsTo(transforms);
                // Draw the model. A model can have multiple meshes, so loop.
                foreach (ModelMesh mesh in model_ground_land1.Meshes)
                {
                    // This is where the mesh orientation is set, as well 
                    // as our camera and projection.
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();
                        effect.World = transforms[mesh.ParentBone.Index] *
                    Matrix.CreateRotationY(cubeGroundLand1_modelRotation) * Matrix.CreateTranslation(cubeGroundLand1_position);
                        effect.View = View;
                        //effect.Texture = text_ground_lan1;
                        effect.Projection = Projection;
                        cubeGroundLand1_position.X = (float)a+1;
                    }
                    // Draw the mesh, using the effects set above.
                    mesh.Draw();
                }
            }
