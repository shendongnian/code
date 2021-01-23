    private void CheckValidation()
    {
        if (PhotograherNumber.Text == "" || errorProvider1.GetError(PhotograherNumber)!= "")
        {
            DisableProcessNow();
            return;
        }
    
        if (EventNumber.Text == "" || errorProvider1.GetError(EventNumber)!= "")
        {
             DisableProcessNow();
             return;
        }
    
        EnableProcessNow();
    }
