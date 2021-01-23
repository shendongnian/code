    public async Task<TResult> HandleServiceCall<TResult>(Func<IPlantOrgQueryService, Task<TResult>> serviceMethod)
    {
        ChannelFactory<IQueryService> channel = new ChannelFactory<IQueryService>("SomeServ_IQuery");
        channel.Open();
        IQueryService newProxy = channel.CreateChannel();
        TResult results = await serviceMethod(newProxy);
        ((IChannel)newProxy).Close();
         return results;
    }
