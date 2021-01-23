    //class variables
    Matrix[] objectTransforms;
    
    //LoadContent section
    cube.model = contentManager.Load<Model>("cub");
    objectTransforms = new Matrix[cube.model.Bones.Count];
    cube.model.CopyAbsoluteTransformsTo(objectTransforms);// the magic is done here
    
    //draw method
    foreach(ModelMesh mm in cube.model.Meshes)
    {
    foreach (BasicEffect bfx in mm.Effects)
    {
       bfx.World = objectTransforms[mm.ParentBone.Index] * whateverLocalTransformYouWant;
       //draw here
    }
    }
