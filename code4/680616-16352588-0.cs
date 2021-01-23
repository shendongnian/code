			modModel = Content.Load<Model>("Cube1");
			foreach (ModelMesh modmModel in modModel.Meshes)
			{
				foreach (ModelMeshPart mmpModel in modmModel.MeshParts)
				{
					modelExtractor = new ModelExtractor(mmpModel, new Vector3[mmpModel.NumVertices * 2], new VertexPositionColor[mmpModel.NumVertices]);
					modelExtractor.ExtractVertices();
				}
			}
			for (int a = 0; a < modelExtractor.ArrVectors.Length; a++)
			{
				Console.WriteLine(modelExtractor.ArrVectors[a]);
			}
			vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), modelExtractor.VpcVertices.Length, BufferUsage.None);
			vertexBuffer.SetData(modelExtractor.VpcVertices);
		}
