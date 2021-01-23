    var Temp = serializer.Deserialize<MyJob>(theAboveJsonString);
        if (Temp.contacts is string)
        {
            jobInfo.contacts = Temp.contacts;
        }
        else
        {
            jobInfo.contacts = String.Join("; ", Temp.contacts );
        }
