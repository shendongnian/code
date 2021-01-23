     TypeDropDownList.Items.Add("Please Specify","");
     foreach (TypeDesc newPatient in EnumToDropDown.EnumToList<TypeDesc>())
     {
        TypeDropDownList.Items.Add(EnumToDropDown.GetEnumDescription(newPatient));
     }
