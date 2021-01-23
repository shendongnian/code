            var required = query.Where(DoesPatientNeedCallback);
            public static bool DoesPatientNeedCallback(Patient p)
            {
                  var last = p.PatientsMasterItem.PatientsTelephoneFollowupDetail.LastOrDefault(c => c.Status == 'Contact Required' || c.Status == 'Contact Purpose Completed);
                  return last != null && last.Status == 'Contact Required'
            
            }
