    public Task<string> DoWorkInSequence()
    {
        return Task.FromResult(4)
               .Then(x => 
                     { if (x != 5)
                       {
                           return Task.FromResult(true)
                                  .Then(y => 
                                        { if (y)
                                          {
                                              return Task.FromResult(x.ToString() + y.ToString());
                                          }
                                          else
                                          {
                                              return Task.FromResult("Nothing");
                                          }
                                        });
                        }
                        else
                        {
                            return Task.FromResult("Nothing");
                        }
                     });
    }
