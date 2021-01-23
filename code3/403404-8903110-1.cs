    public class SliderHelperPackage
    {
        public static readonly DependencyProperty BindThumbToMouseProperty = DependencyProperty.RegisterAttached(
            "BindThumbToMouse", typeof(bool), typeof(SliderHelperPackage), new PropertyMetadata(false, OnBindThumbToMouseChanged));
        public static void SetBindThumbToMouse(UIElement element, bool value)
        {
            element.SetValue(BindThumbToMouseProperty, value);
        }
        public static bool GetBindThumbToMouse(UIElement element)
        {
            return (bool)element.GetValue(BindThumbToMouseProperty);
        }
        private static void OnBindThumbToMouseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue.Equals(e.OldValue))
                return;
            var slider = d as Slider;
            if (slider == null)
                throw new ArgumentException(@"dependency object must be a slider", "d");
            if ((bool) e.NewValue)
            {
                slider.MouseMove += SliderMouseMove;
            }
            else
            {
                slider.MouseMove -= SliderMouseMove;
            }
        }
        static void SliderMouseMove(object sender, MouseEventArgs e)
        {
            var slider = (Slider) sender;
            var position = e.GetPosition(slider);
            // When the mouse moves, we update the slider's value so it's where the ticker is (we take into account margin's on the track)     
            slider.Value = (slider.Maximum - slider.Minimum)*Math.Max(position.X-5,0)/(slider.ActualWidth-10) + slider.Minimum;          
        }
    }
