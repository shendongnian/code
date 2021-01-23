    var contacts = from c in db.Contacts
                  select new {
                               Id = c.ContactID,
                               Name = c.ContactName,
                               Phone = c.ContactOPhone,
                               ...
                               CategoryName = c.Category.CategoryName,
                               DivisionName = c.Division.DivisionName,
                               ContactTitlesName = c.ContactTitle.ContactTitlesName
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
