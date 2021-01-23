    private void CheckValidation()
    {
        if (!IsAllInputValid())
        {
            DisableProcessNow();
            return;
        }
        EnableProcessNow();
    }
    private bool IsAllInputValid()
    {
        if (!HasValidInput(PhotograherNumber))
            return false;
    
        if (!HasValidInput(EventNumber))
            return false;
            
        return true;
    }
    private bool HasValidInput(TextBox textBox)
    {
        if (String.IsNullOrEmpty(textBox.Text)
            return false;
        return errorProvider1.GetError(textBox) != "";
    }
