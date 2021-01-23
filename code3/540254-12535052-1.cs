    public class MyFancyControl : Control
    {
        public MyFancyControl()
        {
            this.DefaultStyleKey = typeof(MyFancyControl);
        }
        // ...
        public override void OnApplyTemplate()
        {
            var myImage = this.GetTemplateChild("MyImageName") as Image;
        }
    }
        
