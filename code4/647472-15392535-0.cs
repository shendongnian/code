    var activityList = 
                (from item in
                    (from member in committeeMemberList
                    let committee = db.Committee.FirstOrDefault(x => x.Committee_Id == item.Committee_Id)
                    let contact = db.Contacts.FirstOrDefault(x => x.Contact_Id == item.Contact_Id)
                    select new
                    {
                       Id = member.Committee_Member_SPE_Id, 
                       Name = committee.Committee_Name, 
                       ...
                       ...
                     }).ToList())
                select new Activity
                {
                   Id = Convert.ToBase64String(item.Id), 
                   Name = committee.Committee_Name, 
                   ...
                   ...
                }).ToList();
