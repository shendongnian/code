    class Program
    {
        static void Main(string[] args)
        {
            // Create and cache the workflow definition
            Activity workflow1 = new Workflow1();
            var names = new[] { "Bob", "Jan", "Ron", "Rick" };
            var arguments = new Dictionary<string, object>() { { "Names", names } };
            WorkflowInvoker.Invoke(workflow1, arguments);
        }
    }
