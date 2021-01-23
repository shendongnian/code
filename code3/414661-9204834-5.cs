    public class Value
    {
        public static readonly DependencyProperty NicknameProperty =
           DependencyProperty.Register("Nickname", typeof(string), typeof(Value), new PropertyMetadata(string.Empty));
        public string Nickname
        {
            get { return (string)GetValue(NicknameProperty); }
            set { SetValue(NicknameProperty, value); }
        }
        public static readonly DependencyProperty FullNameProperty =
           DependencyProperty.Register("FullName", typeof(string), typeof(Value), new PropertyMetadata(string.Empty));
        public string FullName
        {
            get { return (string)GetValue(FullNameProperty); }
            set { SetValue(FullNameProperty, value); }
        }
        public Value()
        {
            Nickname = "Nickname";
            FullName = "FullName";
        }
    }
