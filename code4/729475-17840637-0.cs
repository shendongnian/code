    // Find the nations whose name matches nationReportAbbr
    // Find the nations whose name matches nationReportAbbr
    var matchingNations = _database.SessionDatabaseObject.Nations.Where(nation =>
        String.Equals(nation.ReportAbbreviation, nationReportAbbr, StringComparison.CurrentCultureIgnoreCase));
    if (matchingNations.Any())
    {
        Nation matchingNation = matchingNations.First();
        // Find the sexes whose name matches sexReportAbbr
        var matchingSexes = _database.SessionDatabaseObject.Sexes.Where(sex =>
            String.Equals(sex.Name, sexReportAbbr, StringComparison.CurrentCultureIgnoreCase));
        if (matchingSexes.Any())
        {
            Sex matchingSex = matchingSexes.First();
            // Find the recording sites with the appropriate nation and sex
            var matchingRecordingSites = _database.SessionDatabaseObject.RecordingSites.Where(recordingSite =>
                recordingSite.NationId == matchingNation.Id && recordingSite.SexId == matchingSex.Id);
            if (matchingRecordingSites.Any())
            {
                RecordingSite matchingRecordingSite = matchingRecordingSites.First();
                // Find the interviewers with the appropriate recording site
                var matchingInterviewers = _database.SessionDatabaseObject.Interviewers.Where(interviewer =>
                    interviewer.RecordingSiteId == matchingRecordingSite.Id);
                if (matchingInterviewers.Any())
                {
                    Interviewer matchingInterviewer = matchingInterviewers.First();
                    // Find the readings taken by the appropriate interviewer whose RunEventId matches the provided _entry.Id
                    var matchingReadings = _database.SessionDatabaseObject.Readings.Where(reading =>
                        reading.InterviewerId == matchingInterviewer.Id
                        && reading.RunEventId == _entry.Id);
                    if (matchingReadings.Any())
                    {
                        Reading matchingReading = matchingReadings.First();
                        // Find the height
                        float? height = matchingReading.Height;
                        if (height.HasValue)
                        {
                            return ((int)Math.Floor(height.Value)).ToString();
                        }
                    }
                }
            }
        }
    }
    return String.Empty;
