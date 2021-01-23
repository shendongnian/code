    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace Stackoverflow.Answers.WizardSchema
    {
    
        // Classes to represent your schema
        public class VisibilityDependency
        {
            public int StepID { get; set; }
            public int? TaskID { get; set; } // nullable to denote lack of presense
        }
    
        public class Task
        {
            public int TaskID { get; set; }
            public int TaskOrder { get; set; }
            public string TaskControlID { get; set; }
            public bool IsComplete { get; set; }
            public List<VisibilityDependency> VisibilityDependencyList { get; set; }
        }
    
        public class Step
        {
            // properties in XML
    
            public int StepID { get; set; }
            public string StepTitle { get; set; }
            public List<Task> Tasks { get; set; }
        }
    
        // Class to act as a global context
        public class WizardSchemaProvider
        {
            /// <summary>
            /// Global variable to keep state of all steps (which contani all tasks)
            /// </summary>
            public List<Step> Steps { get; set; }
    
            /// <summary>
            /// Current step, determined by URL or some other means
            /// </summary>
            public Step CurrentStep { get { return null; /* add some logic to determine current step from URL */ } }
    
            /// <summary>
            /// Default Constructor; can get data here to populate Steps property
            /// </summary>
            public WizardSchemaProvider()
            {
                // Init; get your data from DB
            }
    
            /// <summary>
            /// Utility method - returns all tasks that match visibility dependency for the current page;
            /// Designed to be called from a navigation control;
            /// </summary>
            /// <param name="step"></param>
            /// <returns></returns>
            private IEnumerable<Task> GetAllTasksToDisplay(Step step)
            {
    
                // Let's break down the visibility dependency for each one by encapsulating into a delegate;
                Func<VisibilityDependency, bool> isVisibilityDependencyMet = v =>
                {
                    // Get the step in the visibility dependency
                    var stepToCheck = Steps.First(s => s.StepID == v.StepID);
    
                    if (null == v.TaskID)
                    {
                        // If the task is null, we want all tasks for the step to be completed
                        return stepToCheck
                            .Tasks // Look at the List<Task> for the step in question
                            .All(t => t.IsComplete); // make sure all steps are complete
    
                        // if the above is all true, then the current task being checked can be displayed
                    }
    
                    // If the task ID is not null, we only want the specific task (not the whole step)
                    return stepToCheck
                        .Tasks
                        .First(t => t.TaskID == v.TaskID) // get the task to check
                        .IsComplete;
                };
    
                // This Func just runs throgh the list of dependencies for each task to return whether they are met or not; all must be met
                var tasksThatCanBeVisible = step
                    .Tasks
                    .Where(t => t.VisibilityDependencyList
                        .All(v => isVisibilityDependencyMet(v)
                    ));
    
                return tasksThatCanBeVisible;    
            }
    
            public List<string> GetControlIDListForTasksToDisplay(Step step)
            {
                return this.GetAllTasksToDisplay(this.CurrentStep).Select(t => t.TaskControlID).ToList();
            }
    
        }
    
    }
