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
                         }).ToList());
    //After Collecting information just update current value to base4string using following Syntax
    activityList.ForEach(s=>s.id=(s.id==null?"noimage":Convert.ToBase4String(s.id));
