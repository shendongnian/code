    foreach(GeneralPercentageQueue cq in p.GetGeneralEmailPercentageData(start,end)
                                          .OfType<GeneralPercentageQueue>())
    {
        foreach (GeneralPercentageQueue contactqueue in finalDataList.OfType<GeneralPercentageQueue>())
        {
            if (cq.period == contactqueue.period)
            {
                contactqueue.mail_answer_percentage = cq.mail_answer_percentage;
            }
        }
    }
