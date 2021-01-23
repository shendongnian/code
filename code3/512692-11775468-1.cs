                    for (int R = 1; R <= Area.Rows.Count; R++)
                    {
                    Excel.Range Row = ((Excel.Range)Area[R, "A"]);
                    if(Row.Font.Color != Excel.XlRgbColor.rgbGreen)
                    {
                       // Get data from the cells and include into a
                       // collection of items that represents data to be exported.
                    }
                    }
