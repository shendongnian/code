    public ActionResult DisplayEmpPhotos(string EventName, string EventDates, bool consultant)
    {
       ViewData["EventName"] = EventName;
       ViewData["EventDates"] = EventDates;
   
       if(consultant)
       {
           ViewData["Image"] = "<img src ='imgsrc' alt='First&nbsp;Last' class='nopad'/>";
           ViewData["Name"] = "First&nbsp;Last";
           ViewData["Deparment"] = "C";
           ViewData["Title"] = "Consultant";
       }
    }
