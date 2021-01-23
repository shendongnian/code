    public class SomeClassThatCallsAnAction
    {
        public Action SomeAction {get;set;}
    
        private void CallTheAction()
        {
            if (SomeAction != null)
               SomeAction();
        }
    }
    public class ClassThatDefinesTheAction:
    {
        private SomeClassThatCallsAnAction instance;
    
        private void SomeMethod()
        {
              instance = new SomeClassThatCallsAnAction;
              instance.SomeAction = ThisIsTheAction;
        }
    
        private void ThisIsTheAction()
        {
            MessageBox.Show("Action Executed!!);
        }
    }
