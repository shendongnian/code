    private void refreshPostIt()
        {
            // Button btn; is defined somewhere else
            Storyboard sb = new Storyboard();
            DoubleAnimation rotate = new DoubleAnimation();
            rotate.From = 0;
            rotate.To = 360;
            rotate.RepeatBehavior = RepeatBehavior.Forever;
            RotateTransform rt = new RotateTransform();
            btn.RenderTransformOrigin = new Point(0.5, 0.5);
            btn.RenderTransform = rt;
            Storyboard.SetTarget(rotate, btn);
            Storyboard.SetTargetName(rotate, btn.Name);
            Storyboard.SetTargetProperty(rotate, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
            sb.Children.Add(rotate);
            sb.Begin(btn, true);
            
                // Do your stuff here (Not in the UI Thread)
                // Maybe use a semaphore to lock the sb.Stop(btn)
            sb.Stop(btn);
        }
