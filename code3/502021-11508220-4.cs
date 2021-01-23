    public abstract class AMyForm : Form, IMyForm
    {
        void IBrowser.Init()
        {
            InitImpl();
            // And anything else you need...
        }     
        // Or abstract...
        protected virtual void InitImpl()
        {
        }
    }
