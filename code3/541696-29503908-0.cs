    private void pg_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
            string className = e.ChangedItem.PropertyDescriptor.ComponentType.Name;
            string propertyName = e.ChangedItem.PropertyDescriptor.Name;
            var oldValue = e.OldValue;
            var newValue = e.ChangedItem.Value;
            //Record the above variables in your undo class
            //Something like
            RedoClass.AddToUndoList(className,propertyName,oldValue);
    }
