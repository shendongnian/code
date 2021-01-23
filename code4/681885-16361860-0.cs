    //Draw Map
    BoundingFrustum bf = new BoundingFrustum(View * Projection);
    for (int i = 0; i < 499; i++)
    {
        for (int j = 0; j < 499; j++)
        {
            if (bf.Intersects(new BoundingSphere(voxels[i, j].Position, voxelRadius)))
                spriteBatch.Draw(groundVoxelTexture, voxels[i, j].Position, Color.White);
        }
    }
