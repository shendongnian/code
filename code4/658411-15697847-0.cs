    DateTime startDateTime = DateTime.Today; //Today at 00:00:00
    DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1); //Today at 23:59:59
    
    var result = (from a in cxt.visitor.OrderByDescending(n => n.singin)
                where (a.singin >= startDateTime && a.singin <= endDateTime)
                select new {a.visitorid, a.visitorname, a.visitingperson, a.phonenumber, a.reasonforvisit, a.signature, a.singin });
