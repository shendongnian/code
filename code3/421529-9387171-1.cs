    if (type == typeof(string))
    {
      generatedControl = new Textbox();
      generatedControl.DataBindings.Add("Text", myObject, property.Name);
    }
