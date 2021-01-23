     public sealed partial class UCNotes : UserControl
    {
     
        public string selection
        {
            get { return (string)GetValue(selectionProperty); }
            set { SetValue(selectionProperty, value); }
        }
        public static readonly DependencyProperty selecionadoProperty =
            DependencyProperty.Register("selection", typeof(string), typeof(UCNotes), new PropertyMetadata(null));
