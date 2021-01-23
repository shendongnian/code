            [Editor("System.ComponentModel.Design.CollectionEditor, System.Design", typeof(UITypeEditor))]
        [MergableProperty(false)]
        [Category("Data")]
        [DescriptionAttribute("ToolStripItems")]
        public virtual ToolStripItemCollection ToolstripItems
        {
            get => toolStrip.Items;
        }
