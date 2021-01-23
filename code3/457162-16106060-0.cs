       foreach (DropDownEnum enumValue in Enum.GetValues(typeof(DropDownEnum)))
            {
                model.SortOptions.Add(new SelectListItem()
                {
                    Text = enumValue.ToString(),
                    Value = url+enumValue.ToString(),
                    Selected = false
                    
                });
            }
