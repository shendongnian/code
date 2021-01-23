    DateTime previousDate = new DateTime();
    DateTime currentDate = new DateTime();
    foreach (ApproverVo approver in approvers)
    {
    	if (previousDate != new DateTime())
    	{
    		currentDate = (DateTime)approver.ApprovalDate;
    		totalTimeSpan += (currentDate - previousDate).TotalDays;
    		previousDate = currentDate;
    	} else
    		previousDate = (DateTime)approver.ApprovalDate;
    }
