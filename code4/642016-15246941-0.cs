    clientStageCommand = new ClientStepCommand
    {
        CommandType = ClientStageCommandType.Eval,
        Argument = string.Format(@"WelcomeMessageMaster(""{0}"")", this.Grid.UniqueID)
    };   
