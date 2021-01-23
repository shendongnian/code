       this.Dispatcher.BeginInvoke(new System.Action(delegate()
                {
    int num = mCorners.Length;
            VertexPositionColor[] primitiveList = new VertexPositionColor[num];
    
            for (int i = 0; i < num; ++i)
            {
                primitiveList[i] = new VertexPositionColor(new Vector3(mCorners[i], 0), Color.White);
            }
    
            short[] triangleStripIndices = new short[] { 0, 1, 2, 3, };
            graphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(PrimitiveType.LineStrip, primitiveList, 0, 4, triangleStripIndices, 0, 3);
    
    
                }));
