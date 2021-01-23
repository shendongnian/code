    //Search for key in appuser given by de and set appuser property to de.value
    public void appuserfill(DictionaryEntry de, ref appuser _au) { // <- There's no need in "ref"
      if (Object.ReferenceEquals(null, de))
        throw new ArgumentNullException("de");
      else if (Object.ReferenceEquals(null, _au))
        throw new ArgumentNullException("_au");
    
      PropertyInfo pInfo = _au.GetType().GetProperty(de.Key.ToString(), BindingFlags.Instance | BindingFlags.Public);
    
      if (Object.ReferenceEquals(null, pInfo))
        throw new ArgumentException(String.Format("Property {0} is not found.", de.Key.ToString()), "de");
      else if (!pInfo.CanWrite)
        throw new ArgumentException(String.Format("Property {0} can't be written.", de.Key.ToString()), "de");
    
      pInfo.SetValue(_au, de.Value);
    }
