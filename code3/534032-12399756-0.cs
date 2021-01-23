    public class MvvmTextEditor : TextEditor
    {
        public static DependencyProperty CaretOffsetProperty = 
            DependencyProperty.Register("CaretOffset", typeof(int), typeof(MvvmTextEditor),
            new PropertyMetadata((obj, args) =>
            {
                MvvmTextEditor target = obj as MvvmTextEditor;
                target.CaretOffset = (int)args.NewValue;
            })
        );
        public new int CaretOffset
        {
            get { return base.CaretOffset; }
            set { base.CaretOffset = value; }
        }
    }
