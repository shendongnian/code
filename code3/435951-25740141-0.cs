    public class Base : MonoBehaviour
    {
        void Update()
        {
            /* will not run if has inheritor that was setted as component */
            RunInUpdate();
        }
    
        protected virtual void RunInUpdate()
        {
            /* all that you want in Update in base class*/
        }
    }
    
    public class Class : Base
    {
        void Update()
        {
            RunInUpdate();
        }
    
        protected override void RunInUpdate()
        {
            base.RunInUpdate();
            /*your code*/
        }
    }
