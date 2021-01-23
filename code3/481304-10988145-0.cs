    Matrix RotationMatrix;
    //every time I wanted to rotate around an axis, I would do something like this:
    protected void rotateY()
        {
            RotationMatrix *= Matrix.CreateFromAxisAngle(RotationMatrix.Up, MathHelper.ToRadians(1.0f));
            //For the X axis I used RotationMatrix.Right, and for the Z RotationMatrix.Forward
        }
    protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
      
        Matrix shipTransformMatrix = RotationMatrix * Matrix.CreateTranslation(ship.Position);
                        DrawModel(ship.Model, shipTransformMatrix, ship.Transforms);
        // TODO: Add your drawing code here
        base.Draw(gameTime);
    }
    public  void DrawModel(Model model, Matrix modelTransform, Matrix[] absoluteBoneTransforms)
    {
        //Draw the model, a model can have multiple meshes, so loop
        foreach (ModelMesh mesh in model.Meshes)
        {
            //This is where the mesh orientation is set
            foreach (BasicEffect effect in mesh.Effects)
            {
                effect.World = absoluteBoneTransforms[mesh.ParentBone.Index] * modelTransform;
                effect.Projection = projectionMatrix;
                effect.View = viewMatrix;
            }
            //Draw the mesh, will use the effects set above.
            mesh.Draw();
        }
    }
