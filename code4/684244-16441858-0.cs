     public class RegexValidationBehavior : Behavior<TextBox>
    {
        public static readonly DependencyProperty RegexStringProperty =
            DependencyProperty.Register("RegexString", typeof(string), typeof(RegexValidationBehavior), new PropertyMetadata(string.Empty));
        public string RegexString
        {
            get { return GetValue(RegexStringProperty) as string; }
            set { SetValue(RegexStringProperty, value); }
        }      
        protected override void OnAttached()
        {
            base.OnAttached();
            if (AssociatedObject != null)
            {
                AssociatedObject.TextChanged += OnTextChanged;
            }
            Validate();
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject != null)
            {
                AssociatedObject.TextChanged -= OnTextChanged;
            }
        }
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Validate();
        }
        private void Validate()
        {
            var value = AssociatedObject.Text;
            if (value.IsNotEmpty() && RegexString.IsNotEmpty())
            {
                MatchAgainstRegex(value);
            }
        }
        private void MatchAgainstRegex(string value)
        {            
            var match = Regex.Match(value, RegexString);
            if (!match.Success)
            {
                AssociatedObject.Text = value.Remove(value.Length - 1);
                AssociatedObject.Select(AssociatedObject.Text.Length, 0);
            }           
        }
    }
