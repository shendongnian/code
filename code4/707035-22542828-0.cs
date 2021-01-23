            For Each appointment As EmailMessage In service.FindItems(WellKnownFolderName.Inbox, New SearchFilter.SearchFilterCollection(LogicalOperator.And, New SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, False)), New ItemView(999))
                ' set as read 
                appointment.IsRead = True
                appointment.Update(ConflictResolutionMode.AlwaysOverwrite)
            Next
