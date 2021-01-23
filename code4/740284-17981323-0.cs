        var peopleAutoComplete =
                                context.People
                                .Select(c => new { c.Firstname, c.Surname })
                                .ToArray();
       List<string> peopleAutoCompleteString = new List<string>();
       foreach (var item in peopleAutoComplete)
       {
             peopleAutoCompleteString.Add(item.Surname + " " + item.Firstname);
       }
       AutoCompleteStringCollection collectionSource = new AutoCompleteStringCollection();
       collectionSource.AddRange(peopleAutoCompleteString.ToArray());
       txtbx_Surname.AutoCompleteCustomSource = collectionSource;
