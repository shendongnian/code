	public void ExtractVertices()
	{
		this.mmpModel.VertexBuffer.GetData<Vector3>(this.arrVectors);
		for (int a = 0; a < vpcVertices.Length; a += 2)
		{
			this.vpcVertices[a].Position.X = arrVectors[a].X;
			this.vpcVertices[a].Position.Y = arrVectors[a].Y;
			this.vpcVertices[a].Position.Z = arrVectors[a].Z;
		}
	}
