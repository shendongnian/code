		_effect.Texture = texture; // This sets the texture up so the 
		// shaders associated with this effect can access it
		
		// The color in each vertex is modulated with the texture color 
		// and linearly interpolated across vertices
		_effect.VertexColorEnabled = true;
		
		foreach (var pass in _effect.CurrentTechnique.Passes)
		{
			pass.Apply(); // This sets up the shaders and their state
			
			// TriangleList means that the indices are understood to be 
			// multiples of 3, where the 3 vertices pointed to are comprise
			// one triangle
			_device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList,
			
			// The vertices. Note that there can be any number of vertices in here.
			// What's important is the indices array (and the vertexOffset, primitivecount, vertexCount) that determine
			// how many of the provided vertices will actually matter for this draw call
                                                          _vertices, 
			// The offset to the first vertex that the index 0 in the index array will refer to
			// This is used to render a "part" of a bigger set of vertices, perhaps shared across
			// different objects
														  0,
			// The number of vertices to pick starting from vertexOffset. If the index array 
			// tried to index a vertex out of this range then the draw call will fail.
                                                          _vertices.Count,
			// The indices (count = multiple of 3) that comprise separate triangle (because we said TriangleList - 
			// the rules are different depending on the primitive type)
                                                          _indices, 
			// Again, an offset inside the indices array so a part of a larger index array can be used
														  0,
			// Number of indices. This HAS to be a multiple of 3 because we said we're rendering
			// a list of triangles (TrangleList).
                                                          kvp.Value.Indices.Count / 3);
		}
