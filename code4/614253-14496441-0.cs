        // This is necessary to show the property on design mode.
        [Browsable(true)] 
        // This is necessary to serialize the value.
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] 
        public override string Text
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }
