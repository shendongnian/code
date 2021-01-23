    public int SelectedPaymentMethodId { get; set; }
    
    public IEnumerable<SelectListItem> PaymentMethodChoices 
    {
         get 
         {
              return from x in dataSourceFoo
                     select new SelectListItem { 
                          Text = x.TextThing, Value = x.Id, Selected = (x.Id == SelectedPaymentMethodId) 
                      };
         }
    }
