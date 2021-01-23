    // in your init code...
    textbox.TextChanged+=(s,e)=>Validate();
    
    
    // and this is the Validation worker
    BackgroundWorker validateWorker = null;
    bool isValid = false;
    
    private void Validate(){ 
      if (validateWorker != null){
        validateWorker.CancelAsync();
      }
      isValid = false;
      string validateValue = textbox.Text;
    
      BackgroundWorker localCopy = validateWorker = new BackgroundWorker(); 
      validateWorker.WorkerSupportsCancellation = true;
      validateWorker.DoWork+=(s,e)=>{
        if (CoolValidationAssumed(validateValue) && !localCopy.CancellationPending)
           isValid = true;
      };
      validateWorker.RunWorkerCompleted += (s, e) =>{
         if (!localCopy.CancellationPending && !isValid)
           textbox.Color = Colors.Red;
      }
      validationWorker.RunWorkerAsync();
    }
