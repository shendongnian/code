    var contacts =
                (
                    from c in context.ContactSet
                    join m in context.py3_membershipSet on c.ContactId equals m.py3_Member.Id
                    where m.statuscode.Value == 1
                    where ((c.FirstName != null && c.FirstName == searchTerm) || (c.LastName!=null && c.LastName == searchTerm) || (c.FullName != null && c.FullName == searchTerm))  
                    orderby c.LastName
                    select new
                    {
                        ContactId = c.ContactId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        BranchCode = c.py3_BranchArea,
                        Branch = (c.FormattedValues != null && c.FormattedValues.Contains("py3_brancharea") ? c.FormattedValues["py3_brancharea"] : "N/a"),
                        JobTitle = c.JobTitle,
                        Organisation = (c.ParentCustomerId != null ? c.ParentCustomerId.Name : "N/a"),
                        joinedAsCode = c.py3_SOLACEMemberJoinedAs,
                        JoinedAs = (c.FormattedValues != null && c.FormattedValues.Contains("py3_solacememberjoinedas") ? c.FormattedValues["py3_solacememberjoinedas"] : "N/a"),
                        Expertise = (c.py3_SOLACEMemberAreasofExpertise != null && c.py3_SOLACEMemberAreasofExpertise.Trim() != String.Empty ? c.py3_SOLACEMemberAreasofExpertise : "N/a"),
                        Title = c.Salutation
                    }
                );
