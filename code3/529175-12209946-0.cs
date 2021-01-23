        public void Draw(Matrix projection, Matrix view)
        {
            // Copy any parent transforms.
            var transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);
            foreach (var mesh in model.Meshes)
            {
                // This is where the mesh orientation is set, as well 
                // as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    Matrix world = Orientation; // <- A Matrix that is the orientation
                    world.Translation = Position; // <- A Vector3D representing position
                    effect.World = transforms[mesh.ParentBone.Index] *
                        world;
                    effect.View = view;
                    effect.Projection = projection;
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }
