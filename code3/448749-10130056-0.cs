    for (int i = 0; i < cameraObject.Length; i++) 
    { 
        cameraObject[i].Draw(view, projection, cameraObject[i].Position); 
    } 
    //later in the draw method
    public void Draw(Matrix view, Matrix projection, Vector3 pos)
    {
      // ...
      myEffect.World = transforms[myMesh.ParentBone.Index] * Matrix.CreateTranslation(pos);
      // ...
    }
