                 for (int x = 0; x < bmp.Width; x++)
                {
                    //set the new image's pixel to the invert version
                    nRow[x * pixelSize] = (byte)(255 - oRow[x + 0]); //changed from nRow to oRow
                    nRow[x * pixelSize + 1] = (byte)(255 - oRow[x + 1]); //G
                    nRow[x * pixelSize + 2] = (byte)(255 - oRow[x + 2]); //R
                }
