        public object DataSource
        {
            get
            {
            	return fooListBox.DataSource;
            }
            set
            {
                fooListBox.DataSource = value;
            }
        }
        public string DisplayMember
        {
            get { return fooListBox.DisplayMember; }
            set { fooListBox.DisplayMember = value; }
        }
        public string ValueMember
        {
            get { return fooListBox.ValueMember; }
            set
            {
                if ((value != null) && (value != ""))
                    fooListBox.ValueMember = value;
            }
        }
        public string LookupMember
        {
            get
            {
                if (fooListBox.SelectedValue != null)
                    return fooListBox.SelectedValue.ToString();
                else
                    return "";
            }
            set
            {
                if ((value != null) && (value != ""))
                    fooListBox.SelectedValue = value;
            }
        }
