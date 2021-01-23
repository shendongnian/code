    var specificSubContents = SubContentRevisions.Where(s => 
                   s.SubContentID.Equals("e3f319f1-65cc-4799-b84d-309941dbc1da")
    var query = from s in specificSubContents
                where s.RevisionNumber = s.Max(s1 => s1.RevisionNumber)
                select s;
