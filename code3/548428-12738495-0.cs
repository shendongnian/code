    var disp = UserError.RegisterHandler(error => {
         // TODO: Make this better :) 
         MessageBox.Show(error.ErrorMessage);
         return null;
    });
    // Unregister the error handler for the Window once it closes
    this.OnClose += (o,e) => disp.Dispose();
    this.SaveCommand
        .Where(_ => IsObjectValid())
        .Subscribe(_ -> SaveTheObject());
    this.SaveCommand
        .Where(_ => !IsObjectValid())
        .Subscribe(_ -> UserError.Throw("The form is invalid"));
