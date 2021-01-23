    public partial class StartWindowUserControl : UserControl
    {
        public delegate void newDelegate();
        public static event newDelegate new;
    MethodA()
    {
       new();
