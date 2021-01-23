    public Font GetFont(Panel Wathermark, string textToPaint)
            {
                    Font result = new Font("Bold", 1);
                    using (Graphics measure = Wathermark.CreateGraphics())
                    {
                        SizeF tempSize;
                        tempSize = measure.MeasureString(textToPaint, result);
                        
                        while (tempSize.Width < Wathermark.Width && tempSize.Height < Wathermark.Height)
                        {
                            tempSize = measure.MeasureString(textToPrint, result);
                            var tempSizeToIncrease = result.Size; //writeprotected
                            result = new Font(result.Name, tempSizeToIncrease += 0.1f);
                        }
                    }
                    return result;
                }
