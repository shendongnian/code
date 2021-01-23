    DateTime ExpectedSubDate;
    string strExpectedSubDate = gr.Cells[3].Text;
    if(DateTime.TryParse(strExpectedSubDate, out ExpectedSubDate))
    {
        DateTime AuthReqDate;
        string strAuthReqDate = gr.Cells[8].Text;
        if(!DateTime.TryParse(strAuthReqDate, out AuthReqDate))
        {
            if(DateTime.Now < ExpectedSubDate)
            {
                SendMail();
            }
        }
    }
                     
