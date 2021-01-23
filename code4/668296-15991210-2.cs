      protected internal bool IsDataBindingAutomatic
        {
          get
          {
            if (!this.IsBoundUsingDataSourceID)
              return this.IsUsingModelBinders;
            else
              return true;
          }
        }
