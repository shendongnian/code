    private static void AddImageToRun(Run run, string imageFileName, long imageWidthEMU, long imageHeightEMU, string imageID)
            {
                try
                {
                    string GraphicDataUri =http://schemas.openxmlformats.org/drawingml/2006/picture";
    
                    var element =
                         new Drawing(
                             new DW.Inline(
                                 new DW.Extent() { Cx = imageWidthEMU, Cy = imageHeightEMU },
    
                                 new DW.EffectExtent()
                                 {
                                     LeftEdge = 0L,
                                     TopEdge = 0L,
                                     RightEdge = 0L,
                                     BottomEdge = 0L
                                 },
                                 new DW.DocProperties()
                                 {
                                     Id = (UInt32Value)1U,
                                     Name = imageFileName,
                                     Description = imageFileName
                                 },
                                 new DW.NonVisualGraphicFrameDrawingProperties(
                                     new A.GraphicFrameLocks() { NoChangeAspect = true }),
    
                                 new A.Graphic(
                                     new A.GraphicData(
                                         new PIC.Picture(
    
                                             new PIC.NonVisualPictureProperties(
                                                 new PIC.NonVisualDrawingProperties()
                                                 {
                                                     Id = (UInt32Value)0U,
    
                                                     Name = imageFileName
                                                 },
                                                 new PIC.NonVisualPictureDrawingProperties()),
    
                                             new PIC.BlipFill(
                                                 new A.Blip()
                                                 {
                                                     Embed = imageID
                                                 },
                                                 new A.Stretch(
                                                     new A.FillRectangle())),
                                             new PIC.ShapeProperties(
                                                 new A.Transform2D(
                                                     new A.Offset() { X = 0L, Y = 0L },
    
                                                     new A.Extents()
                                                     {
                                                         Cx = imageWidthEMU,
                                                         Cy = imageHeightEMU
                                                     }),
    
                                                 new A.PresetGeometry(
                                                     new A.AdjustValueList()
                                                 ) { Preset = A.ShapeTypeValues.Rectangle }))
                                     ) { Uri = GraphicDataUri })
                             )
                             {
                                 DistanceFromTop = (UInt32Value)0U,
                                 DistanceFromBottom = (UInt32Value)0U,
                                 DistanceFromLeft = (UInt32Value)0U,
                                 DistanceFromRight = (UInt32Value)0U,
                             });
    
                    // Append the reference to body, the element should be in a Run.
                    run.AppendChild(element);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
