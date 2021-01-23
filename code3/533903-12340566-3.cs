    [WebMethod(EnableSession = true)]
    public static string GetEvents(string userID)
    {
        DataClassesDataContext db = new DataClassesDataContext();
    List<calevent> eventList = db.calevents.ToList();
    // Select events and return datetime as sortable XML Schema style.
    var events = from ev in eventList
                 select new
                 {
                     id = ev.event_id,
                     title = ev.title,
                     info = ev.description,
                     start = ev.event_start.ToString("s"),
                     end = ev.event_end.ToString("s"),
                     user = ev.user_id
                 };
    // Serialize to JSON string.
    JavaScriptSerializer jss = new JavaScriptSerializer();
    String json = jss.Serialize(events);
    return json;
    }
