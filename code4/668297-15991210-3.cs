    protected override bool IsUsingModelBinders
        {
          get
          {
            if (string.IsNullOrEmpty(this.SelectMethod) 
                && string.IsNullOrEmpty(this.UpdateMethod) 
                && string.IsNullOrEmpty(this.DeleteMethod))
              return !string.IsNullOrEmpty(this.InsertMethod);
            else
              return true;
          }
        }
