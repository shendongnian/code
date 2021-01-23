                Activity activity = ActivityXamlServices.Load(path);
                IDictionary<string, object> dictionary = new Dictionary<string, object>
                {
                    { "Arg", 1},
                };
                IDictionary<string, object> output = WorkflowInvoker.Invoke(activity, dictionary);
