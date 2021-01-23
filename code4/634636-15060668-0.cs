    DateTime previousDate = DateTime.MinValue;
    DateTime currentDate = new DateTime();
    foreach (ApproverVo approver in approvers)
    {
    	if (previousDate != DateTime.MinValue)
    	{
    		currentDate = (DateTime)approver.ApprovalDate;
    		totalTimeSpan += (currentDate - previousDate).TotalDays;
    		previousDate = currentDate;
    	} else
    		previousDate = (DateTime)approver.ApprovalDate;
    }
