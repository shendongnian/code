    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraEditors.Controls;
    
    private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e) {
        GridView view = sender as GridView;
        if(view.FocusedColumn.FieldName == "Discount") {
            //Get the currently edited value 
            double discount = Convert.ToDouble(e.Value);
            //Specify validation criteria 
            if(discount < 0) {
                e.Valid = false;
                e.ErrorText = "Enter a positive value";
            }
            if(discount > 0.2) {
                e.Valid = false;
                e.ErrorText = "Reduce the amount (20% is maximum)";
            }
        }
    }
    
    private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e) {
        //Do not perform any default action 
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        //Show the message with the error text specified 
        MessageBox.Show(e.ErrorText);
    }
