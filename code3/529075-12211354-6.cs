        public void Method()
        {
            ((CompareValidator)e.Item.FindControl("cmvQuantity")).ValueToCompare = "Test value";
            ((CompareValidator)e.Item.FindControl("cmvQuantity")).ControlToValidate = "txtControlId";
        }
    Implement it as:
        public void Method()
        {
           CompareValidator cmvQuantity = e.Item.FindControl("cmvQuantity") as CompareValidator;
           if (cmvQuantity != null)
           {
               cmvQuantity.ValueToCompare = "Test value";
               cmvQuantity.ControlToValidate = "txtControlId";
           }
        }
