    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (gv.EditIndex == e.Row.RowIndex)
            {
                TextBox tb = e.Row.Cells[0].Controls[0] as TextBox; // get reference to your Control to validate (you specify cell and control indeces)
                tb.ID = "reg_" + e.Row.RowIndex; // give your Control to validate an ID
    
                CompareValidator cv = new CompareValidator(); // Create validator and configure
                cv.Operator = ValidationCompareOperator.GreaterThan;
                cv.Type = ValidationDataType.Double;
                cv.Display = ValidatorDisplay.Dynamic;
                cv.ErrorMessage = "<br/>Not a valid number";
                cv.ForeColor = Color.Red;
                cv.ControlToValidate = tb.ID;
                e.Row.Cells[0].Controls.Add(cv); // Add validator to GridView cell
            }
        }
    }
