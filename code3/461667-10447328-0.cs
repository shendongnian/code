    if (command.Parameters != null)
    {
        foreach (object parameter in command.Parameters)
        {
            IDisposable disposableParameter = parameter as IDisposable;
            if (disposableParameter != null)
            {
                disposableParameter.Dispose();
            }
        }
    }
