public void StartProcess()
{
    while(true) {
        try {
            //Everything the service does.
        }
        catch (Exception ex)
        {
              _serviceContainer.GetInstance<IErrorLogRepository>().Log(ex: ex);
              Thread.Sleep(300 * 1000);
         }
    }
}
