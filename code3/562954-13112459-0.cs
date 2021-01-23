db.MeetingPurposes.Include("Dates").ToList();
    public ActionResult GetMeetingMR(int id = 0)
    {
        //Load the MeetingPurposes including their dates
        var meetingPurpose = db.MeetingPurposes.Include("Dates").ToList();
        ViewBag.MeetingPurpose = new SelectList(meetingPurpose,
                                                "MeetingPurposeID",
                                                "MeetingPurposeName");
        ViewBag.MRID = id;
        List<Meeting> meetings = (db.MortgageRequests.Find(id)).Meetings.ToList();
        return View(meetings);
    }
