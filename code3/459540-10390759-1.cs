    private void CheckValidation()
    {
        if (String.IsNullOrEmpty(PhotograherNumber.Text) || errorProvider1.GetError(PhotograherNumber)!= "")
        {
            DisableProcessNow();
            return;
        }
    
        if (String.IsNullOrEmpty(EventNumber.Text) || errorProvider1.GetError(EventNumber)!= "")
        {
             DisableProcessNow();
             return;
        }
    
        EnableProcessNow();
    }
