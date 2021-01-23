    public ConcreteResponse SomeWebMethod()
            {
                ConcreteResponse response = new ConcreteResponse();
    
                try
                {
                    // Processing here
                }
                catch (Exception exception)
                {
                    // Log the actual exception details somewhere
    
                    // Replace the exception with user friendly message
                    response.HasErrors = true;
                    response.Errors = new Collection<string>();
    
                    response.Errors[0] = exception.Message;
                }
                finally
                {
                    // Clean ups here
                }
    
                return response;
            }
