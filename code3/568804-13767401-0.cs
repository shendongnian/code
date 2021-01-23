    catch (Exception ex)
    {
        XEvent e = new XEvent();
        e.Type = XEventType.Exception;
        e.Data = .........; // some calculations here
       using (XDataContext dc2 = new XDataContext())
       {
        dc2.XEvents.InsertOnSubmit(e);
        dc2.SubmitChanges(); // 3
       }
    }
