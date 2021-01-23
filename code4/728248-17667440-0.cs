    var cs = ApplicationContext.Current.Services.ContentService;
    foreach(var content in yourListOfContentItems)
    {
        cs.SaveAndPublish(content);
    }
