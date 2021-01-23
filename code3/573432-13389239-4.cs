    public void UpdateFrom( ModelMeshPart meshPart ) {
       var indices = new short[meshPart.IndexBuffer.IndexCount];
       meshPart.IndexBuffer.GetData<short>( indices );
       var vertices = new float[meshPart.VertexBuffer.VertexCount 
                              * meshPart.VertexBuffer.VertexDeclaration.VertexStride/4];
       meshPart.VertexBuffer.GetData<float>( vertices );
       // Usually first three floats are position, 
       // this way don't need to know what vertex struct is used
       for ( int i=meshPart.StartIndex; i<meshPart.StartIndex + meshPart.PrimitiveCount*3; i++ ) {
         int index = (meshPart.VertexOffset + indices[i]) *
                      meshPart.VertexBuffer.VertexDeclaration.VertexStride/4;
         position = new Vector3(vertices[index] , vertices[index+1], vertices[index+2]));
         UpdateFrom(position);
      }
    }
    
    public void UpdateFrom(Vector3 point) {
       if (point.X > box.Max.X) box.Max.X = point.X;
       if (point.X < box.Min.X) box.Min.X = point.X;
       ....
    }
