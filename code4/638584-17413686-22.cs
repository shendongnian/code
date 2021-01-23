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
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PagedFragmentRecordNoteBox : RecordNoteBox
    {
        public Fragment ParentFragment { get; set; }
        public RecordView.IFragmentToViewPagerEvent PagerListener { get; set; }
        
        private PagedFragmentRecordNoteBoxInput _pagedFragmentFieldInput;
        // sometime u need this, other times you don't - mono's missing nuts that android don't
        //public PagedFragmentRecordNoteBox(IntPtr jRef, JniHandleOwnership handle) : base(jRef, handle) { }
        public PagedFragmentRecordNoteBox(Context context) : base(context) { }
        public PagedFragmentRecordNoteBox(Context context, IAttributeSet attributes) : base(context, attributes) { }
        public PagedFragmentRecordNoteBox(Context context, IAttributeSet attributes, int defStyle) : base(context, attributes, defStyle) { }
        protected override RecordNoteBoxInput InstantiateInput()
        {
            // Since I was getting inflation exception when the layout file 
            // PagedFragmentRecordRecordNoteBoxInput.axml had only a single, not wrapped in any ViewGroup, I had to 
            // wrap it up in a linear layout (whatever). Since this view will be added somewhere else, it needs to 
            // be removed from the wrapper (hence the call to RemoveAllViews - comment it out to see what happens).
            //LayoutInflater inflater = (LayoutInflater)_context.ApplicationContext.GetSystemService(Context.LayoutInflaterService);
            View v = _inflater.Inflate(Resource.Layout.PagedFragmentRecordRecordNoteBoxInput, null);
            
            _pagedFragmentFieldInput = ((ViewGroup)v).FindViewById<PagedFragmentRecordNoteBoxInput>(Resource.Id.fi_record_note_box_input);
            ((ViewGroup)v).RemoveAllViews();
            _pagedFragmentFieldInput.OuterClass = this;
            return (RecordNoteBoxInput)_pagedFragmentFieldInput;
        }
        protected class PagedFragmentRecordNoteBoxInput : RecordNoteBoxInput
        {
            public PagedFragmentRecordNoteBox OuterClass { get; set; }
            private Context _context { get; set; }
            // sometime u need this, other times you don't - mono's missing nuts that android don't
            //public PagedFragmentRecordNoteBoxInput(IntPtr jRef, JniHandleOwnership handle) : base(jRef, handle) { }
            public PagedFragmentRecordNoteBoxInput(Context context) : base(context) { _context = context; }
            public PagedFragmentRecordNoteBoxInput(Context context, IAttributeSet attributes) : base(context, attributes) { _context = context; }
            public PagedFragmentRecordNoteBoxInput(Context context, IAttributeSet attributes, int defStyle) : base(context, attributes, defStyle) { _context = context; }
            public override bool OnTouchEvent(MotionEvent e)
            {
                Log.Info(FIDB.TAG_APP, "PagedFragmentFieldInput.OnTouchEvent: BEGIN");
                OuterClass.PagerListener.ParcelRecordFieldClickEvent(OuterClass.ParentFragment, this);
                RequestFocus();
                InputMethodManager imm = (InputMethodManager)_context.GetSystemService(Context.InputMethodService);
                imm.ShowSoftInput(this, Android.Views.InputMethods.ShowFlags.Forced);
                return base.OnTouchEvent(e);
            }
        }
    }
