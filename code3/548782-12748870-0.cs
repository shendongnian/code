     Public Structure VertexPositionColorNormal
    	 Public Position As Vector3
    	 Public Color As Color
    	 Public Normal As Vector3
    
    	 Public ReadOnly Shared VertexDeclaration As New VertexDeclaration( _
    		New VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0), _
    		New VertexElement(Len(New Single) * 3, VertexElementFormat.Color, VertexElementUsage.Color, 0), _
    		New VertexElement(Len(New Single) * 3 + 4, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0))
     End Structure
