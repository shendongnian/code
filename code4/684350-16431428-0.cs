        public void Update(MouseInput mouse)
        {
                if (mouse.LeftClicked())
                {
                    for (int i = 0; i < drawTangle.Count; i++)
                    {
                        if (mouse.clickRectangle.Intersects(drawTangle[i]))
                        {
                            diseaseToInfo = listOfInfo[i];
                            isDrawingList = false;
                            moreInfo = true;
                        }
                    }
                }
        }
