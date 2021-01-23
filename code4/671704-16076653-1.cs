    catch (Exception err)
    {
        if(this.Dispatcher.CheckAccess()){
           txtErrors.AppendText(err.Message);
        }
        else {
               Action<Exception> act = ((ex) => {
                txtErrors.AppendText(ex.Message);
               }); 
            this.Dispatcher.Invoke(act, new object[] { err });
        }
    }
