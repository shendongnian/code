    public static List<T> GetControlsOfType<T>(this ControlCollection controls)
    {
      List<T> resultList = new List<T>();
      foreach (Control control in controls)
      {
        if (control is T)
          resultList.Add((T)((object)control));
        if (control.Controls.Count > 0)
        {
          resultList.AddRange(GetControlsOfType<T>(control.Controls));
        }
      }
      return resultList;
    }
    
	public object GetFieldValue(ListFieldIterator lfi, string fieldName)
    {
      FormField formField = lfi.Controls.GetControlsOfType<FormField>().Where(f => f.FieldName == fieldName).FirstOrDefault();
      if (formField == null) return null;
      return formField.Value;
    }
