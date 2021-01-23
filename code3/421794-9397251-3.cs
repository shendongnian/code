    public ApplicationViewModel SelectedApplication
    {
        get
        {
            if (this.InvokeRequired)
            {
                ApplicationViewModel value = null; // compiler requires that we initialize this variable
                // the call to Invoke will block until the anonymous delegate has finished executing.
                this.Invoke((MethodInvoker)delegate
                {
                    // anonymous delegate executing on UI thread due calling the Invoke method
                    // assign the result to the value variable so that we can return it.
                    value = _applicationsCombobox.SelectedItem as ApplicationViewModel;
                });
                return value;
            }
            else
            {
                return _applicationsCombobox.SelectedItem as ApplicationViewModel;
            }
        }
    }
