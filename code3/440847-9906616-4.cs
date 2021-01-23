    protected override void Invoke(object parameter)
    {            
        base.Invoke(parameter);
        Send(PassedObject, NavigationToken);
    }
    void Send(ViewModelBase objectToSend, string navigationToken)
    {
        var genericMessageType = typeof(NavigatingMessage<>)
        var viewModelType = objectToSend.GetType();
        var messageType = genericMessageType.MakeGenericType(viewModelType);
        var message = Activator.CreateInstance(messageType, this, objectToSend);
        
        var method = typeof(Messenger).GetMethods()
                                      .Single(x => x.Name == "Send" &&
                                                   x.GetParameters().Count() == 2 &&
                                                   x.GetParameters()
                                                    .First()
                                                    .ParameterType
                                                    .GetGenericTypeDefinition()
                                                     == genericMessageType);
        method.MakeGenericMethod(viewModelType)
              .Invoke(Messenger.Default, new [] { message, navigationToken });
    }
