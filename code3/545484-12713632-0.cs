    using System;
    using System.Activities.Statements;
    using System.Threading;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            // Setup the sample workflow.
            var workflow = new Sequence
                {
                    Activities =
                        {
                            new WriteLine { Text = "Hello World!" },
                            new Delay { Duration = TimeSpan.FromSeconds(3) },
                            new WriteLine { Text = "Done!" }
                        }
                };
    
            // Setup the workflow host.
            var syncWorkflowEvent = new AutoResetEvent(false);
            var workflowApp = new WorkflowApplication(workflow);
            workflowApp.Completed = eventArgs => syncWorkflowEvent.Set();
            workflowApp.Run();
            syncWorkflowEvent.WaitOne();
        }
    }
