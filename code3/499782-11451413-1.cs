    public void Post(ViewModel model)
    {
        var entity = ...;
        entity.DoNotEmail = !model.SendEmailNotification;
    }
