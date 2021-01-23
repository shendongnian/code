    public XInstanceProvider :IInstanceProvider
    {
    ....
    public object GetInstance(InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            
            return new ServiceX();
        }
    }
