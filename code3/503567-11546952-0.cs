        /// <summary>Calculates the absolute bone transformation matrices in model space</summary>
        private void calculateAbsoluteBoneTransforms() {
         
          // Obtain the local transform for the bind pose of all bones
          this.model.CopyBoneTransformsTo(this.absoluteBoneTransforms);
         
          // Convert the relative bone transforms into absolute transforms
          ModelBoneCollection bones = this.model.Bones;
          for (int index = 0; index < bones.Count; ++index) {
         
            // Take over the bone transform and apply its user-specified transformation
            this.absoluteBoneTransforms[index] =
              this.boneTransforms[index] * bones[index].Transform;
         
            // Calculate the absolute transform of the bone in model space.
            // Content processors sort bones so that parent bones always appear
            // before their children, thus this works like a matrix stack,
            // resolving the full bone hierarchy in minimal steps.
            ModelBone bone = bones[index];
            if (bone.Parent != null) {
              int parentIndex = bone.Parent.Index;
              this.absoluteBoneTransforms[index] *= this.absoluteBoneTransforms[parentIndex];
            }
          }
         
        }
