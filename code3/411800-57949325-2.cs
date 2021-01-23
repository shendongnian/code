    public void FillComboBox(string[] array, ComboBox box)
    {
     foreach(string x in array)
      {
       box.Items.Add(x);
      }
    }
