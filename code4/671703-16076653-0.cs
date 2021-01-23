    catch (Exception err)
    {
        if(this.InvokeRequired){
            Action<Exception> act = ((ex) => {
                txtErrors.AppendText(ex.Message);
            }); 
            this.Invoke(act, new object[] { err });
        }
        else{
            txtErrors.AppendText(err.Message);
        }
    }
