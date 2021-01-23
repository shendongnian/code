      ContactGroup.Add(new {
                           ContactGroupKey = Convert.ToInt64(DB["ContactGroupKey", "0"]),
                           ContactGroupTLK = Convert.ToInt64(DB["TranslationKey", "0"]),
                           Desc = DB["Description", ""].ToString(),
                           Contacts=GenerateList(Contact)
                           });
