    public virtual Binding GetBinding(string fieldName)
    {
        string[] pieces = fieldName.Split('.');
        if ( pieces.GetLength(0) == 1 )
        {
            return new Binding("Text", this, fieldName);
        }
        else
        {
            return new Binding("Text",
                Current.GetType().GetProperty(pieces[0]).GetValue(Current, null), pieces[1]);
        }
    }
    // Calling the helper function and adding the binding
    EditField.DataBindings.Add(Controller.GetBinding(mapping.FieldName));
