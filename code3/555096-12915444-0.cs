    public class MvxButtonIconBinding: MvxBaseAndroidTargetBinding
    {
        private readonly View _view;
        public MvxButtonIconBinding(View view)
        {
            _view = view;
        }
        public override void SetValue(object value)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "pictures");
            path = Path.Combine(path, (string)value);
            if (File.Exists(path))
            {
                var dr = Drawable.CreateFromPath(path);
                Button b = _view as Button;
                var drawables = b.GetCompoundDrawables();
                foreach (var d in drawables)
                    if (d!=null)
                        d.Dispose(); // To avoid "out of memory" messages
                b.SetCompoundDrawablesWithIntrinsicBounds(null, dr, null, null);
            }
            else
            {
                Console.WriteLine("File {0} does not exists", path);
            } 
        }
        
        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWay; }
        }
        public override Type TargetType
        {
            get { return typeof(string); }
        }
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
            }
            base.Dispose(isDisposing);
        }
    }
