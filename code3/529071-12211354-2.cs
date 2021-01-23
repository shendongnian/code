    public void Method()
    {
       CompareValidator cmvQuantity = e.Item.FindControl("cmvQuantity") as CompareValidator;
       if (cmvQuantity != null)
       {
           cmvQuantity.ValueToCompare = "Test value";
           cmvQuantity.ControlToValidate = "txtControlId";
       }
    }
