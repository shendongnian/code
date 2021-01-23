        private void DrawModel(Model model, Matrix worldMatrix)
        {
            //Matrix array for number of bones
            Matrix[] modelTransformations = new Matrix[model.Bones.Count];
            //Put bones into matrix array
            model.CopyAbsoluteBoneTransformsTo(modelTransformations);
            //for every model
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    //Add default lighting
                    effect.EnableDefaultLighting();
                    //Set default postion
                    effect.World = modelTransformations[mesh.ParentBone.Index] * worldMatrix;
                    //Set view
                    effect.View = camera.viewMatrix;
                    //Set projection
                    effect.Projection = camera.projectionMatrix;
                }
                //Draw Model
                mesh.Draw();
            }
        }
