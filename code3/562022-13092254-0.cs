    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    
    namespace SimpleAnimation
    {
        public class Body
        {
            Model bodyModel;
            ModelBone headBone;
            ModelBone bodyBone;
            Matrix headTransform;
            Matrix bodyTransform;
            Matrix[] boneTransforms;
    
            public Body()
            {
                HeadScale = 1;
            }
    
            public void Load(ContentManager content)
            {
                // Load the tank model from the ContentManager.
                bodyModel = content.Load<Model>("body");
    
                // Look up shortcut references to the bones we are going to animate.
                headBone = bodyModel.Bones["head"];
                bodyBone = bodyModel.Bones["body"];
    
                // Store the original transform matrix for each animating bone.
                headTransform = headBone.Transform;
                bodyTransform = bodyBone.Transform;
    
                // Allocate the transform matrix array.
                boneTransforms = new Matrix[bodyModel.Bones.Count];
            }
    
            public void Draw(Matrix world, Matrix view, Matrix projection)
            {
                // Set the world matrix as the root transform of the model.
                bodyModel.Root.Transform = world;
    
                // Calculate matrices based on the current animation position.
                Matrix headRotation = Matrix.CreateRotationX(HeadRotation);
                Matrix headScale = Matrix.CreateScale(HeadScale);
                Matrix bodyRotation = Matrix.CreateRotationX(BodyRotation);
    
                // Apply matrices to the relevant bones.
                headBone.Transform = headScale * headRotation * headTransform;
                bodyBone.Transform = bodyRotation * bodyTransform;
    
                // Look up combined bone matrices for the entire model.
                bodyModel.CopyAbsoluteBoneTransformsTo(boneTransforms);
    
                // Draw the model.
                foreach (ModelMesh mesh in bodyModel.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.World = boneTransforms[mesh.ParentBone.Index];
                        effect.View = view;
                        effect.Projection = projection;
    
                        effect.EnableDefaultLighting();
                    }
    
                    mesh.Draw();
                }
            }
    
            public float HeadRotation { get; set; }
    
            public float HeadScale { get; set; }
    
            public float BodyRotation { get; set; }
        }
    }
