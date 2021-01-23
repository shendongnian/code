    var myList = mt.ToList();
    foreach (var mtype in myList)
    {
        foreach (var mess in mtype.LibMessages.ToList())
        {
            if (mess.VisibleEndDate < DateTime.Now)
            {
                // remove expired message. 
                mtype.LibMessages.Remove(mess);
            }
        }
    }
