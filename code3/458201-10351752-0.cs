    public class CustomButton : Button
    {
        static CustomButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomButton), 
               new FrameworkPropertyMetadata(typeof(CustomButton)));
        }
        public static readonly DependencyProperty SubjectProperty =
            DependencyProperty.Register("Subject", typeof (string),
            typeof (CustomButton), new PropertyMetadata(default(string)));
        public string Subject
        {
            get { return (string) GetValue(SubjectProperty); }
            set { SetValue(SubjectProperty, value); }
        }
    }
