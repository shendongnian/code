    public class Model
    { 
        public int progress;
        public event EventHandler ProgressChanged;
        public int Progress
        {
            get { return progress; }
            set 
            { 
                progress = value;
                if (ProgressChanged != null)
                {
                    ProgressChanged(this, null);
                }
            }
        }
    }
    public class Copy
    {
        public List<Model> models = new List<Model>();
        public event EventHandler CopyProgrss; // FormModel binded to this event. 
        public void AddModel(Model m)
        {
            this.models.Add(m);
            m.ProgressChanged += new EventHandler(m_ProgressChanged);
        }
        void m_ProgressChanged(object sender, EventArgs e)
        {
            Model currentModel = sender as Model;
            int modelProgress = currentModel.Progress;
            if (CopyProgrss != null)
                CopyProgrss(modelProgress,null); // here you can caluclate your over progress. 
        }
    }
