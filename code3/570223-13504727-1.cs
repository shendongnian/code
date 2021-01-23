    void HandleTextChanged(object source, ...) {
      var input = source as TextBox;
      var property = input.Tag as PropertyInfo;
      property.GetSetMethod().Invoke(this.instanceOfThatType, new object[] { Convert.ChangeType(input.Text, property.PropertyType) });
    }
