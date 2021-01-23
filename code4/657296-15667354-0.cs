    public static ProcessResultDC StartProcess<T, TResult>(
      T setupData,
      string processName,
      Func<T, TResult> fn,
      string exteriorAccountNumber,
      string companyCode
    )
      where T : IAmValidatable, IHaveAProcessGuid
    {
      var result = new ProcessResultDC { Status = ProcessStatusEnum.Accepted };
      // Do some authentication stuff here
      try
      {
        result.Result = fn(setupData);
      }
      catch (Exception exc)
      {
        result.Status = ProcessStatusEnum.Error;
        result.Messages.Add(exc.Message);
      }
      
      return result;
    }
