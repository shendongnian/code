using System.Windows.Forms;
    protected void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            if (Application.OpenForms.Count == 0) return; 
            var mainForm = Application.OpenForms[0];
            if(mainForm == null) return; // No main form - no calls
            
            if (mainForm.InvokeRequired) 
            {
                // We are not in UI Thread now
                mainform.Invoke(handler, new object[] {
                   this, new PropertyChangedEventArgs(propName)});
            }
            else
            {
                handler(this, new PropertyChangedEventArgs(propertyName)); 
            }              
        }
    }
