     private void UpdateBindings()
        {
          for (int index = 0; index < this.DataBindings.Count; ++index)
            BindingContext.UpdateBinding(this.BindingContext, ((BindingsCollection) this.DataBindings)[index]);
        }
