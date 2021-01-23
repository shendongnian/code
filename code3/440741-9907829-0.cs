    While wfWhile = new While();
    Variable<int> stepNo = new Variable<int>("stepNo", 0);
    wfWhile.Variables.Add(stepNo);
    
    wfWhile.Body = new Sequence()
    {
        Activities = {
            new WriteLine
            {
                Text = new VisualBasicValue<string>("\"Step: \" & stepNo ")
            },
            new Assign<int>()
            {
                    To = new OutArgument<int>(stepNo),
                    Value= new VisualBasicValue<int>("stepNo + 1")
            }
                     
            }
    };
    wfWhile.Condition = new VisualBasicValue<bool>("stepNo < 10");
    WorkflowInvoker.Invoke(wfWhile);
