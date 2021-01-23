     public valueAllocation declaringValue()
        {
            valAlloc.setValue(5);
            int testAlloc = valAlloc.getValue();
            lblResult.Text="Value set here is:"+testAlloc;  //THIS WORKS!!!
            return valAlloc;
        }
    
    protected void btnSaveValue_Click(object sender, ImageClickEventArgs e)
        {
            declaringValue()
            lblResult.Text = "Value now is:" + declaringValue().getValue();   //DOESNT WORK??????!!!!!
        }
