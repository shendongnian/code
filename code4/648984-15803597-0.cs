     while (retryCount <= MAXRETRY)
                {
                    try
                    {
                        return _proxyService.GetData(); // _proxyService is WCF proxy class
                    }
                    catch (CommunicationException transientException)
                    {
                         if (SLEEPINTERVAL> 0)
                        {
                            Thread.Sleep(SLEEPINTERVAL);
                        }
                        ((IClientChannel) _proxyService).Abort();
                        _proxyService = functionToCreateProxy();
                    }
                 
                    retryCount++;
                }
