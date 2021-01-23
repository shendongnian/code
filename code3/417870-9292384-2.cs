        var wf = new DynamicActivity<int>
        {
            Properties =
             {
                new DynamicActivityProperty { Name = "Operand1", Type = typeof(InArgument<int>) },
                new DynamicActivityProperty { Name = "Operand2", Type = typeof(InArgument<int>) }
             },
            Implementation = () => new Sequence()
                {
                    Activities =
                    {
                        new WriteLine
                        {
                            Text =
                                new VisualBasicValue<string>(
                                "Operand1 & \" + \" & Operand2")
                        },
                        new Assign<int>
                        {
                            To = new ArgumentReference<int> { ArgumentName = "Result" },
                            Value = new VisualBasicValue<int>("Operand1 + Operand2")
                        }
                    }
                }
        };
        var inputs = new Dictionary<string, object>();
        inputs["Operand1"] = 7;
        inputs["Operand2"] = 42;
        var output = WorkflowInvoker.Invoke(wf, inputs);
        Console.WriteLine(output);
