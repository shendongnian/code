        public enum SearchType
            {
                ReferenceData = 0,
                Trade = 1,
            }
    Then use `SelectedIndexChanged` event of `radioGroup` control.
    
            private void RadioTypes_SelectedIndexChanged(object sender, EventArgs e)
            {
               if (this.RadioTypes.SelectedIndex < 0) return;
    
                SearchType n = (SearchType)this.RadioTypes.SelectedIndex;
    
                switch (n)
                {
                    case SearchType.ReferenceData:
    
                        break;
    
                    case SearchType.Trade:
    
                        break;
                }
            }
