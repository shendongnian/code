    int LeftColumn = Camera.X / A; // let it round to nearest lower int
    int TopRow = Camera.Y / A;
    
    LeftColumn = LeftColumn % N; // Calculate the first tile
    TopRow = TopRow % M;
    
    for (int i = LeftColumn+N; i < LeftColumn+2*N; i++)
      for (int l = TopRow+M; l < TopRow+2*M; l++)
      // you may check here if the tile is visible or not based on the screen size
      {
        Tile[i % N, l % M].Draw(i*A, l*A); // Or do whatever you like
      }
