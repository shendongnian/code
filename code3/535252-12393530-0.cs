    private void FNF()
        {
            int XMX = 0;
            int moveX= 0;
            int moveY = 0;
            int MH = RectBin.Height;
            int MW = RectBin.Width;
            int c1 = Items.Count;
            rectsToDraw = new List<Rectangle>();
            for(int i = 0; i < c1; i++)
            {
                int height = Oblici[i].Height;
                int width = Oblici[i].Width;
                if(((moveY + height) <= MV)&&((moveX+width)<=MW))
                {
                    rectsToDraw.Add(new Rectangle(moveX, moveY, width, height));
                    moveY = moveY + height;
                    if (XMX < moveX + width)
                    {
                        XMX = moveX + width;
                    }
                }
                else if((XMX + width) <= MW)
                {
                    moveX = XMX;
                    rectsToDraw.Add(new Rectangle(moveX, 0, width, height));
                    moveY = height;
                    XMX = moveX + width;
                }
                else
                {
                    Debug.Write("Doesn't fit.");
                    break;
                }
            }
            for (int j = 0; j < rectsToDraw.Count; j++)
            {
                Debug.Write(rectsToDraw[j]);
            }
        }
