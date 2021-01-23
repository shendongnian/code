    var sessions = results.Select(cbtAppointmentDto => Session.QueryOver<TestSession>()
                             .Where(x => x.SessionName == cbtAppointmentDto.ExamSeriesCode)
                             .FutureValue()).ToOList();
    for (int i = 0; i < sessions.Count; i++)
    {
        var session = sessions[i].Value;
        if (session != null)
        {
            results[i].TestStartDate = session.TestsStartDate;
            results[i].TestEndDate = session.TestsEndDate;
        }
    }
