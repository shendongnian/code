      var dpd = DependencyPropertyDescriptor.FromProperty(YourTextBoxClass.TextProperty, typeof(YourTextBoxClass));
     if (dpd != null)
     {
         dpd.AddValueChanged(this, ThisIsCalledWhenPropertyIsChanged);
     }    
