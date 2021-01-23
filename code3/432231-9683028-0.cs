            try
            {
                fnBirthDayReminder();
                if (strDay == "SUNDAY" || strDay == "TUESDAY" || strDay == "THURSDAY")
                {
                    fnAwaitingLeaveApplicationReminder();
                }
                fnLeavePlanRemainder();
                fnContractExpiryRemainder();
            }
            catch (Exception ex)
            { 
            
            }
            Application.Exit();
