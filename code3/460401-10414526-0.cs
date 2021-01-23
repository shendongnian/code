    foreach (DeArtIzm izm in colRindas)
         {
             objectData[i, 0] = izm.ArtCode;
             objectData[i, 1] = izm.ArtName;
             objectData[i, 2] = izm.Price;
             objectData[i, 3] = izm.RefPrice;
             i++;//Place where I get that error
         }
