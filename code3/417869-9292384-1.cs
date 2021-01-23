    var wf = new Sequence()
    {
        Variables =
        {
            new Variable<int>("Operand1", 7),
            new Variable<int>("Operand2", 42)
        },
        Activities =
        {
            new WriteLine
            {
                Text =
                    new VisualBasicValue<string>(
                    "Operand1 & \" + \" & Operand2")
            }
        }
    };
    
    
    WorkflowInvoker.Invoke(wf);
