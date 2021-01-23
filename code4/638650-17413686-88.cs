    public class RecordNoteBoxInput : EditText
    {
        // sometime u need this, other times you don't - mono's missing nuts that android don't
        //public RecordNoteBoxInput(IntPtr jRef, JniHandleOwnership handle) : base(jRef, handle) { }
        public RecordNoteBoxInput(Context context) : base(context) { }
        public RecordNoteBoxInput(Context context, IAttributeSet attributes) : base(context, attributes) { }
        public RecordNoteBoxInput(Context context, IAttributeSet attributes, int defStyle) : base(context, attributes, defStyle) { }
    }
    
    public class RecordNoteBox : LinearLayout
    {
        protected Context _context;
        protected LayoutInflater _inflater;
        protected RecordNoteBoxInput _inputFiled;
        public RecordNoteBoxInput Input
        {
            get { return _inputFiled; }
            set { _inputFiled = value; }
        }
        protected virtual RecordNoteBoxInput InstantiateInput()
        {
            return (RecordNoteBoxInput)_inflater.Inflate(Resource.Layout.RecordNoteBoxInput, this, false);
        }
        protected void Init(Context context)
        {
            _context = context;
            _inflater = LayoutInflater.From(context);
            _inputFiled = InstantiateInput(); 
            
            this.AddView(_inputFiled);
        }
        // sometime u need this, other times you don't - mono's missing nuts that android don't
        //public RecordNoteBox(IntPtr jRef, JniHandleOwnership handle) : base(jRef, handle) { }
        
        public RecordNoteBox(Context context) : base(context) { Init(context); }
        public RecordNoteBox(Context context, IAttributeSet attributes) : base(context, attributes) { Init(context); }
        public RecordNoteBox(Context context, IAttributeSet attributes, int defStyle) : base(context, attributes, defStyle) { Init(context); }
    }
