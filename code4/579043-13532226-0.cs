    abstract class AbstractMyActions {
        
        protected SomeType commonMethodForBothProjects() {
            ...
        }
    }
    public class MyActionsA extends AbstractMyActions {
         public SomeType doJob(SomeParameter ..., SomeParameter ...) {
             $this->commonMethodForBothProjects();
             // Additional steps
         }
    }
