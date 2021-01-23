    public class MyTabControl : TabControl
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var panel = Template.FindName("HeaderPanel", this) as FrameworkElement;
            if(panel != null)
            {
                panel.Margin = new Thickness(20,2,2,2);
            }
        }
    }
