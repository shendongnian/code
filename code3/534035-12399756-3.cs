    public class MvvmTextEditor : TextEditor
    {
        public static DependencyProperty CaretOffsetProperty = 
            DependencyProperty.Register("CaretOffset", typeof(int), typeof(MvvmTextEditor),
            // binding changed callback: set value of underlying property
            new PropertyMetadata((obj, args) =>
            {
                MvvmTextEditor target = (MvvmTextEditor)obj;
                target.CaretOffset = (int)args.NewValue;
            })
        );
        public new int CaretOffset
        {
            get { return base.CaretOffset; }
            set { base.CaretOffset = value; }
        }
        public int Length { get { return base.Text.Length; } }
        protected override void OnTextChanged(EventArgs e)
        {
            RaisePropertyChanged("Length");
            base.OnTextChanged(e);
        }
    }
