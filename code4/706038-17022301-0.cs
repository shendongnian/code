    class SearchForm
    {
        public void SearchForm(IEnumerable<Control> contentControls)
        {
            foreach(var contentControl in contentControls)
            {
                this.Controls.Add(contentControl);
            }
        }    
    }
