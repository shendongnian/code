        private System.Windows.Forms.ListBox dropdownsource = new ListBox();
        [Category("Data")]
        [Browsable(true)]
        [DefaultValue(null)]
        [System.ComponentModel.Bindable(true)]
        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
        [Editor("System.Windows.Forms.Design.DataSourceListEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))]
        public object DataSource
        {
            get
            {
                return this.dropdownsource.DataSource;
            }
            set
            {
                if (this.dropdownsource.DataSource != value)
                    this.dropdownsource.DataSource = value;
            }
        }
        
