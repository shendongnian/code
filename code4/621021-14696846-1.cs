        partial class SafetyIssue
        {
   
        }
   
        partial class SafetyIssueTotals
        {
           public void RefreshTotals(List<SafetyIssue> safetyIssues)
           {
               TotalSubmissions = safetyIssues.Count(c => c.SafetyCategory == 1);
               TotalInductions = safetyIssues.Count(c => c.SafetyCategory == 2);
               TotalSafetyMeetings = safetyIssues.Count(c => c.SafetyCategory == 3); 
               TotalToolboxTalk = safetyIssues.Count(c => c.SafetyCategory == 4);
               TotalRecognitions = safetyIssues.Count(c => c.SafetyCategory == 5);
               TotalIncidents = safetyIssues.Count(c => c.SafetyCategory == 6);
               ActualSafetySubmissions = safetyIssues.Count(c => c.JobSafetyNo.Trim() != "");
           }
    
        }
    
    
        partial class JobNumber:IDataErrorInfo
        {
            partial void OnLoaded()
            {
               CalculateSafetyIssueTotals(); //moved the call to the function here. 
            }
    
            public void CalculateSafetyIssueTotals()
            {
                if (SafetyIssuesTotals == null)
                    SafetyIssuesTotals = new SafetyIssuesTotals();
 
    
                SafetyIssuesTotals.TotalActualSafetySubmissions = SafetyIssues.Count;
                SafetyIssuesTotals.TotalIncidents =
                    SafetyIssues.Count(s => s.SafetyCategory1 != null && s.SafetyCategory1.SafetyCategoryID == 6);
                SafetyIssuesTotals.TotalInductions =
                    SafetyIssues.Count(s => s.SafetyCategory1 != null && s.SafetyCategory1.SafetyCategoryID == 2);
                SafetyIssuesTotals.TotalRecognitions =
                    SafetyIssues.Count(s => s.SafetyCategory1 != null && s.SafetyCategory1.SafetyCategoryID == 5);
                SafetyIssuesTotals.TotalSafetyMeetings =
                    SafetyIssues.Count(s => s.SafetyCategory1 != null && s.SafetyCategory1.SafetyCategoryID == 3);
                SafetyIssuesTotals.TotalSubmissions =
                    SafetyIssues.Count(s => s.SafetyCategory1 != null && s.SafetyCategory1.SafetyCategoryID == 1);
                SafetyIssuesTotals.TotalToolboxTalk =
                    SafetyIssues.Count(s => s.SafetyCategory1 != null && s.SafetyCategory1.SafetyCategoryID == 4);
            }
    
        }
