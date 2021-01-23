    public bool HasChanges(object entity, string property)
    {
        List<SavedState> list;
        if (!_savedStates.TryGetValue(entity, out list))
            throw new ArgumentException("Before call the HasChanges method you should call the Save method.");
        SavedState savedState = list.FirstOrDefault(state => state.PropertyInfo.Name == property);
        if (savedState == null)
            return false;
        object newValue = savedState.PropertyInfo.GetValue(entity);
        return !Equals(newValue, savedState.Value);
    }
