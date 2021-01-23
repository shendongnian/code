    struct surroundingTiles
    {
        static bool blockNE;
        static bool blockN;
        static bool blockNW;
        static bool blockW;
        static bool blockSW;
        static bool blockS;
        static bool blockSE;
        static bool blockE;
    }
    foreach(object tile in floor)
    {
        if(currentTile.surroundingTiles.blockW && currentTile.surroundingTiles.blockNW && currentTile.surroundingTiles.blockN)
            useTexture(currentTile, shadowSEtexture);
    }
