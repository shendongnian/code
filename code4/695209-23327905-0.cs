        {
            get
            {
                List<string> lStringList = new List<string>();
                foreach (string lval in this.mEkaTextBox.AutoCompleteCustomSource)
                {
                    lStringList.Add(lval);
                }
                return lStringList.ToArray();
            }
            set
            {
                txtLocl.AutoCompleteCustomSource.AddRange(value);
            }
        }
