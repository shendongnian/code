    public ActionResult GetMeetingMR(int id = 0)
    {
        var meetingPurpose = db.MeetingPurposes.ToList();
        ViewBag.MeetingPurpose = new SelectList(meetingPurpose,
                                                "MeetingPurposeID",
                                                "MeetingPurposeName");
        ViewBag.MRID = id;
        var meetings = (from mee in db.Meetings.Include("Dates")
                        join mga in dbo.MortgageRequests.Where(m => m.Id == id)
                        on mee.MortgageRequestID equals mga.ID
                        select mee).ToList();
        return View(meetings);
    }
