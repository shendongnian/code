    [HttpPost]
    public void Create(VolunteerEvent volunteerEvent, FormCollection collection)
    {
        var topicId = volunteerEvent.TopicId;
        // do something
        // you can also get the value from collection["TopicId"]
    }
