    ///Kept as arefrence while initial drawing phase.
    private DrawingVisual mDrawingVisual = null;
     if (null != mDrawingVisual)
          {
            using (DrawingContext vDrawingContext = mDrawingVisual.RenderOpen())
            {
              DrawingGroup vDrawingGroup = VisualTreeHelper.GetDrawing(mDrawingVisual);
              if (null != vDrawingGroup)
              {
                foreach (Drawing vDrawing in vDrawingGroup.Children)
                {
                  GeometryDrawing vGeometryDrawing = vDrawing as GeometryDrawing;
                  if (null != vGeometryDrawing)
                  {
                    vGeometryDrawing.Brush = mBackGroundBrush;
                  }
                }
              }
               
              vDrawingContext.DrawDrawing(vDrawingGroup);
              vDrawingContext.Close();
            }
          }
