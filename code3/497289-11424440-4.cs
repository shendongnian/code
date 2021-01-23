    private static void UpdateVisitors()
        {
            System.Collections.Generic.Dictionary<string, DateTime> Visitors = (System.Collections.Generic.Dictionary<string, DateTime>)HttpContext.Current.Application["Visitors"];
            Visitors[HttpContext.Current.Session.SessionID] = DateTime.Now;
        }
