        public class Test : DependencyObject
        {
        public string NameOfPerson
        {
            get { return (string)GetValue(NameOfPersonProperty); }
            set { runmethod(value); }
        }
        private async void runmethod(string value)
        {
             SetValue(NameOfPersonProperty, value);
        }
        public static readonly DependencyProperty NameOfPersonProperty =
            DependencyProperty.Register("NameOfPerson", typeof(string), typeof(Test), new PropertyMetadata("null string"));
        }
