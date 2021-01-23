        public MainClass
        {   
            public void Run()
            {
              skeduler = Skeduler.Instance;
              skeduler.SendRestart += new Skeduler.SendRestartX(MethodToCall);
            }
        }
