     private Storyboard GenerateMoveAnimation(double x, double y)
            {
                var xAnimation = new DoubleAnimation
                                     {
                                         From = TranslateTransform.X,
                                         To = x
                                     };
    
                var yAnimation = new DoubleAnimation
                                     {
                                         From = TranslateTransform.Y,
                                         To = y
                                     };
    
                Storyboard.SetTarget(xAnimation, TranslateTransform);
                Storyboard.SetTargetProperty(xAnimation, new PropertyPath("X"));
    
                Storyboard.SetTarget(yAnimation, TranslateTransform);
                Storyboard.SetTargetProperty(yAnimation, new PropertyPath("Y"));
                
                var str = new Storyboard();
                str.Children.Add(xAnimation);
                str.Children.Add(yAnimation);
    
                return str;
            }
    
            private void GestureListnerDragDelta(object sender, DragDeltaGestureEventArgs e)
            {
                var point = e.GetPosition(LayoutRoot);
                GenerateMoveAnimation(point.X, point.Y).Begin();
            }
            
            private void SurfaceGestureListner_OnTap(object sender, Microsoft.Phone.Controls.GestureEventArgs e)
            {
                var point = e.GetPosition(LayoutRoot);
                GenerateMoveAnimation(point.X, point.Y).Begin();            
            }
