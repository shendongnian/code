     void rotate(int i)
           {            
            Storyboard MyStory = new Storyboard();
            MyStory.Duration = new TimeSpan(0,0,1);           
            DoubleAnimation My_Double = new DoubleAnimation();
            My_Double.Duration =  new TimeSpan(0,0,1);          
            MyStory.Children.Add(My_Double);
            RotateTransform MyTransform = new RotateTransform();
            Storyboard.SetTarget(My_Double, MyTransform);
            Storyboard.SetTargetProperty(My_Double, new PropertyPath("Angle"));
            My_Double.From = i;
            My_Double.To = i +90;
            m_Image.RenderTransform = MyTransform;
            m_Image.RenderTransformOrigin = new Point(0.5, 0.5);            
            MyStory.Begin();
            MyStory.Completed +=((arg,c) =>
            {
                if (i == 360)
                {
                    rotate(0);
                }
                else 
                {
                    rotate(i + 90);
                }        
            });                                
        }
