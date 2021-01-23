    Amazon.SQS.Model.Attribute sentTimestampx = null;
    for (Amazon.SQS.Model.Attribute a : x.getAttributes())
    {
        if (a.Name == "SentTimestamp")
        {
            if (sentTimestampx == null)
            {
                sentTimestampx = a;
            }
            else
            {
                throw new Exception("Boooooh! there is more than one matching elements!");
            }
        }
    }
