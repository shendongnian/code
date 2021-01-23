     private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Storyboard MyStory = new Storyboard();
            MyStory.Duration = new TimeSpan(0, 0, 1);
            DoubleAnimation My_Double = new DoubleAnimation();
            My_Double.Duration = new TimeSpan(0, 0, 1);
            MyStory.Children.Add(My_Double);
            RotateTransform MyTransform = new RotateTransform();
            Storyboard.SetTarget(My_Double, MyTransform);
            Storyboard.SetTargetProperty(My_Double, new PropertyPath("Angle"));
            My_Double.To = 360;
            YourImage.RenderTransform = MyTransform;
            YourImage.RenderTransformOrigin = new Point(0.5, 0.5);       
            MyStory.Begin();
        }
