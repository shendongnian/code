    foreach(PropertyInfo propertyInfo in original.GetType().GetProperties()) {
        if (propertyInfo.GetValue(updatedUser, null) == null)
            propertyInfo.SetValue(updatedUser, propertyInfo.GetValue(original, null), null);
    }
    db.Entry(original).CurrentValues.SetValues(updatedUser);
    db.SaveChanges();
