         protected void DropDownList1_SelectedIndexChanged(object source, EventArg e)
         {
             PriceChangeEventArgs args = new PriceChangeEventArgs();
             args.Price = Convert.ToDecimal(DropDownList1.SelectedValue);
             PriceChanged(this, args);
         }
