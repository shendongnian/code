    Form2 : Form
    {
        public event EventHandler Saved;
        
        OnSaveButtonClicked(...)
        {
            if(Saved != null) Saved(this, new EventArgs());
        }
    }
