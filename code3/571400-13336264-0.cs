    DateTime strExpectedSubDate = DateTime.ParseExact(gr.Cells[3].Text, dateformat);
    DateTime strAuthReqDate = DateTime.ParseExact(gr.Cells[8].Text, dateformat);
    DateTime strDate = System.DateTime.Now;
    if (strAuthReqDate == null && strDate < strExpectedSubDate)
    {
    }
