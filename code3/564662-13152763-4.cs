    public void OpenChildForm()
    {
         ChildForm cf = new ChildForm();
         cf.Show();
         btnRun.Clicked -= OnRunButtonClicked(cf); //important - to avoid multiple-
         btnRun.Clicked += OnRunButtonClicked(cf); //handlers getting attached.
    }  
    private EventHandler OnRunButtonClicked(ChildForm cf)
    {
        return (sender, e) => cf.AddValues();
    }
