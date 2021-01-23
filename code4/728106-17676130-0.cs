    int layerIndex = materialBindlist.IndexOf(currentLayer);
                        for(int i = layerIndex; i < materialBindlist.Count-1; i++)
                        {
                            //set the top position of all other rectangles that are below selected rectangle/row
                            //(Current-Old)+Top
                            double top=Convert.ToDouble((currentHeight - oldHeight) + materialBindlist[i + 1].GlassRectangle.Top);
                            Canvas.SetTop(materialBindlist[i + 1].rectangle,top);
    
                            materialBindlist[i + 1].GlassRectangle.Top = top;
    
    
    
                        }
