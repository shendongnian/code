    private void Cmd_ReplaceColors(ref WriteableBitmap Par_WriteableBitmap,int Par_Limit=180)
            {
    
                for (int y = 0; y < Par_WriteableBitmap.PixelHeight; y++)
                {
                    for (int x = 0; x < Par_WriteableBitmap.PixelWidth; x++)
                    {
    
                        Color color = Par_WriteableBitmap.GetPixel(x, y);
    
                        if (color == Colors.White)
                        {
    
                        }
                        else
                        {
                            if (color.R < Par_Limit)
                            {
                                Par_WriteableBitmap.SetPixel(x, y, Colors.Black);
                            }
                            else
                            {
                                Par_WriteableBitmap.SetPixel(x, y, Colors.White);
                            }
    
                        }
    
                    }
                }
    
                Par_WriteableBitmap.Invalidate();
            }
