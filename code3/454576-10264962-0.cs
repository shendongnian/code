    public string concatFields() {
       string sample = null; // a StringBuilder would be a better choice here
       foreach (FieldInfo f in this.GetType().GetFields()) {
           obj fieldValue = f.GetValue();
           if (fieldValue != null) sample += fieldValue.ToString();
       }
       return sample;
    }
