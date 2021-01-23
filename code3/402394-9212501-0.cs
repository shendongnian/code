    public void TransformBone(Matrix BoneAlteration, int BoneID)
    {
        boneTransform[BoneID] = BoneAlteration * bindPose[BoneID];
        UpdateWorldTransforms(Matrix.Identity);
        UpdateSkinTransforms();
    }
