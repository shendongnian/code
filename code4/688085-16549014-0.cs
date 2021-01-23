    class Cube
	{
		private GraphicsDevice device;
		private VertexBuffer cubeVertexBuffer;
		public Cube(GraphicsDevice graphicsDevice)
		{
			device = graphicsDevice;
			var vertices = new List<VertexPositionTexture>();
			BuildFace(vertices, new Vector3(0, 0, 0), new Vector3(0, 1, 1));
			BuildFace(vertices, new Vector3(0, 0, 1), new Vector3(1, 1, 1));
			BuildFace(vertices, new Vector3(1, 0, 1), new Vector3(1, 1, 0));
			BuildFace(vertices, new Vector3(1, 0, 0), new Vector3(0, 1, 0));
			BuildFaceHorizontal(vertices, new Vector3(0, 1, 0), new Vector3(1, 1, 1));
			BuildFaceHorizontal(vertices, new Vector3(0, 0, 1), new Vector3(1, 0, 0));
			cubeVertexBuffer = new VertexBuffer(device, VertexPositionTexture.VertexDeclaration, vertices.Count, BufferUsage.WriteOnly);
			cubeVertexBuffer.SetData<VertexPositionTexture>(vertices.ToArray());
		}
		private void BuildFace(List<VertexPositionTexture> vertices, Vector3 p1, Vector3 p2)
		{
			vertices.Add(BuildVertex(p1.X, p1.Y, p1.Z, 1, 0));
			vertices.Add(BuildVertex(p1.X, p2.Y, p1.Z, 1, 1));
			vertices.Add(BuildVertex(p2.X, p2.Y, p2.Z, 0, 1));
			vertices.Add(BuildVertex(p2.X, p2.Y, p2.Z, 0, 1));
			vertices.Add(BuildVertex(p2.X, p1.Y, p2.Z, 0, 0));
			vertices.Add(BuildVertex(p1.X, p1.Y, p1.Z, 1, 0));
		}
		private void BuildFaceHorizontal(List<VertexPositionTexture> vertices, Vector3 p1, Vector3 p2)
		{
			vertices.Add(BuildVertex(p1.X, p1.Y, p1.Z, 0, 1));
			vertices.Add(BuildVertex(p2.X, p1.Y, p1.Z, 1, 1));
			vertices.Add(BuildVertex(p2.X, p2.Y, p2.Z, 1, 0));
			vertices.Add(BuildVertex(p1.X, p1.Y, p1.Z, 0, 1));
			vertices.Add(BuildVertex(p2.X, p2.Y, p2.Z, 1, 0));
			vertices.Add(BuildVertex(p1.X, p1.Y, p2.Z, 0, 0));
		}
		private VertexPositionTexture BuildVertex(float x, float y, float z, float u, float v)
		{
			return new VertexPositionTexture(new Vector3(x, y, z), new Vector2(u, v));
		}
		public void Draw( BasicEffect effect)
		{
			foreach (EffectPass pass in effect.CurrentTechnique.Passes)
			{
				pass.Apply();
				device.SetVertexBuffer(cubeVertexBuffer);
				device.DrawPrimitives(PrimitiveType.TriangleList, 0, cubeVertexBuffer.VertexCount / 3);
			}
		}
	}
