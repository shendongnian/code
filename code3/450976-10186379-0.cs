                RectangleGeometry outerRect = new RectangleGeometry(_myRectangle);
                RectangleGeometry geo = new RectangleGeometry(_myCanvasRectangle);
                PathGeometry outerRectLine = outerRect.GetWidenedPathGeometry(new Pen(new SolidColorBrush(Colors.White), _myActualLineWidth));
                PathGeometry intersect = Geometry.Combine(geo, outerRectLine, GeometryCombineMode.Exclude, null);
                
                drawingContext.DrawGeometry(
                    new SolidColorBrush(System.Windows.Media.Color.FromArgb(99, _myObjectColor.R, _myObjectColor.G, _myObjectColor.B)),
                    new System.Windows.Media.Pen(new SolidColorBrush(Colors.White), ActualLineWidth),
                    intersect
                    );
