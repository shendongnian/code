    public DC.Request GetRequest(int requestId)
    {
        var requestManager = this.Container.Resolve<IRequestManager>();
        var request = requestManager.GetRequest(requestId);
        var userMapper = this.Container.Resolve<IMapper<BE.User, DC.User>>();
        var seriesMapper = this.Container.Resolve<IMapper<BE.Series, DC.Series>>();
        var statusMappger = this.Container.Resolve<IMapper<BE.Status, DC.Status>>();
        var mapper = this.Container.Resolve<IMapper<BE.Request, DC.Request>>();
        return mapper.Map(request);
    }
