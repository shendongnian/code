      public BoundingBox Boundingbox
      {
          return new BoundingBox(new Vector3(this.position.X, position.Y, 0f),
                                 new Vector3(this.position.X + spritewidth,position.Y+spriteheight, 0f));
      }
