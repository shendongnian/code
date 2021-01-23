                ActivityXamlServicesSettings settings = new ActivityXamlServicesSettings
                {
                    CompileExpressions = true
                };
                Activity activity = ActivityXamlServices.Load(path, settings);
                IDictionary<string, object> dictionary = new Dictionary<string, object>
                {
                    { "ArgNumberToEcho", 2},
                };
                IDictionary<string, object> output = WorkflowInvoker.Invoke(activity, dictionary);
