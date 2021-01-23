    var contacts = from c in db.Contacts
                  select new {
                               Id = t1.ContactID,
                               Name = t1.ContactName,
                               Phone = t1.ContactOPhone,
                               ...
                               CategoryName = t1.Category.CategoryName,
                               DivisionName = t1.Division.DivisionName,
                               ContactTitlesName = t1.ContactTitle.ContactTitlesName
                             }
    var items = from t1 in db.Item
                select new {
                             Id = t1.ItemID,
                             Name = t1.ItemName,
                             Phone = t1.??, // string.Empty?
                             ... // more properties corresponding
                                 // with the ones above
                             CategoryName = t1.Category.CategoryName,
                             DivisionName = t1.Division.DivisionName,
                             ContactTitlesName = string.Empty
                           }
    var all = contacts.Union(items);
