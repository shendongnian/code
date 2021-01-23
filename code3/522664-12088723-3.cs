    try
    {
        if (SldRange.Count > 0)
        {
            var showWarning = false;
            for (int slideCount = 1; slideCount <= SldRange.Count; slideCount++)
            {
                int shapeCount = 1;
                while (shapeCount <= SldRange[slideCount].Shapes.Count)
                {
                    if (Globals.Ribbons.Ribbon2.itemIDDictionary.ContainsKey(SldRange[slideCount].Shapes[shapeCount].Name))
                    {
                        if (!Globals.Ribbons.Ribbon2.itemIDDictionary.ContainsValue(SldRange[slideCount].Shapes[shapeCount].Id))
                        {
                            SldRange[slideCount].Shapes[shapeCount].Delete();
                            showWarning = true;
                        }
                        else
                        {
                            shapeCount++;
                        }
                    }
                    else
                    {
                        shapeCount++;
                    }
                }
            }
            if(showWarning == true)
            {
                MessageBox.Show("You can not copy the browser object.\nAdd a new one using the ribbon bar");
            }
        }
    }
    catch { }
