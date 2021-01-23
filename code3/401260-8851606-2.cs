        public LabelFormatDelegate ValueFormatter = null;
    
        public string Value 
        {
            get 
            { 
                return value; 
            }
            set 
            { 
                this.value = value; 
                if (this.ValueFormatter != null)
                {
                    this.Text = this.ValueFormatter(value); // change the label here
                }
                else
                {
                    this.Text = value;
                }
            }
        }
