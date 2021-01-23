        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public override string Text 
        { 
            get { return ContentPresenter.Text; } 
            set { ContentPresenter.Text = value; } 
        } 
