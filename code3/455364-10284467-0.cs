    this.ObjectContext.CallLogs
        .Where(c => c.CreatedByID == createdByID)
        .Skip(startRowIndex)
        .Take(maximumRows)
        .Select(new
            {
                            CallLogID = c.CallLogID,
                            DomainName = c.CallDomain.FullName,
                            CreatedByID = c.CreatedByID,
                            CreatedBy = c.CreatedByUser.FirstName + " " + c.CreatedByUser.LastAccessIPN,
                            CalledOn = c.CallDate,
                            IssueResolutionTime = c.IssueResolutionTime,                            
                            CallType = c.CallType.FullName,
                            CallDescription = c.CallDescription,
                            CustomerName = (c.CustomerID > 0 ? c.Customer.FirstName + " " + c.Customer.LastAccessIPN : c.TempCaller.FirstName + " " + c.TempCaller.LastName),
                            CustomerEmail = (c.CustomerID > 0 ? c.Customer.Email : string.Empty),
                            CustomerResponse = c.Response.FullName,
                            IsPending = c.IsPending,
                            NeedFurtherContact = c.NeedFurtherContact
            })
        .ToList();
