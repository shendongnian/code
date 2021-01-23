        public new string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        internal string baseText { get { return base.Text; } set { base.Text = value; } }
        public static DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(MvvmTextEditor),
            // binding changed callback: set value of underlying property
            new PropertyMetadata((obj, args) =>
            {
                LuaTextEditor target = (MvvmTextEditor)obj;
                if(target.baseText != (string)args.NewValue)    //avoid undo stack overflow
                    target.baseText = (string)args.NewValue;
            })
        );
        
        protected override void OnTextChanged(EventArgs e)
        {            
            SetCurrentValue(TextProperty, baseText);
            RaisePropertyChanged("Text");
            base.OnTextChanged(e);
        }
