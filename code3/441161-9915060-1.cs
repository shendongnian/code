    public static class BackgroundImages
    {
        public static readonly DependencyProperty NormalBackgroundImageProperty =
            DependencyProperty.RegisterAttached("NormalBackgroundImage", typeof(ImageSource), typeof(BackgroundImages));
        public static readonly DependencyProperty MouseOverBackgroundImageProperty =
            DependencyProperty.RegisterAttached("MouseOverBackgroundImage", typeof(ImageSource), typeof(BackgroundImages));
        public static readonly DependencyProperty PressedBackgroundImageProperty =
            DependencyProperty.RegisterAttached("PressedBackgroundImage", typeof(ImageSource), typeof(BackgroundImages));
        public static ImageSource GetNormalBackgroundImage(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(NormalBackgroundImageProperty);
        }
        public static void SetNormalBackgroundImage(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(NormalBackgroundImageProperty, value);
        }
        public static ImageSource GetMouseOverBackgroundImage(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(MouseOverBackgroundImageProperty);
        }
        public static void SetMouseOverBackgroundImage(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(MouseOverBackgroundImageProperty, value);
        }
        public static ImageSource GetPressedBackgroundImage(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(PressedBackgroundImageProperty);
        }
        public static void SetPressedBackgroundImage(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(PressedBackgroundImageProperty, value);
        }
    }
