                        objectToPrint.Width = double.NaN;
                    objectToPrint.UpdateLayout();
                    objectToPrint.LayoutTransform = new ScaleTransform(1, 1);
                    Size size = new Size(capabilities.PageImageableArea.ExtentWidth, 
                                         capabilities.PageImageableArea.ExtentHeight);
                    objectToPrint.Measure(size);
                    objectToPrint.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, 
                                          capabilities.PageImageableArea.OriginHeight), size));
