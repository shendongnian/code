    ChildForm _cF; //member field
    public void OpenChildForm()
    {
         _cf = new ChildForm();
         _cf.Show();
    }   
 
    public void OnRunButtonClicked()
    {
         _cf.AddValues();
    }
