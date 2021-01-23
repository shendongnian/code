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
