     var entry = context.ObjectStateManager.GetObjectStateEntry(((IEntityWithKey)object).EntityKey);
      for (int i = 0; i < entry.OriginalValues.FieldCount; i++)
    {
         entry.CurrentValues.SetValue(i, entry.OriginalValues[i]);
    }
    entry.AcceptChanges();
