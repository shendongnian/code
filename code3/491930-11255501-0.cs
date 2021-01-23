    foreach (TypeDesc newPatient in EnumToDropDown.EnumToList<TypeDesc>())
    {
       string text = EnumToDropDown.GetEnumDescription(newPatient)),
       TypeDropDownList.Items.Add(new
       {
           Text = text,
           Value = text == "Please specify" ? null : text // should be replaced with a clean solution
       }
    }
