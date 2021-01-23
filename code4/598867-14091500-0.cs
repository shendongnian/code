    class MainConfigProxy : MainConfig
    {
        public override Enabled
        {
             get { return base.Enabled; }
             set
             {
                 base.Enabled = value;
                 mainSession.Save();
             }
        }
    }
