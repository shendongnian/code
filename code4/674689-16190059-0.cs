        void Start()
        {
            var tmp = Loom.Current;
            ...
        }
        //Function called from other Thread
        public void NotifyFinished(int status)
        {
            Debug.Log("Notify");
            try
            {
                if (status == (int)LevelStatusCode.OK)
                {
                    Loom.QueueOnMainThread(() =>
                    {
                        PresentNameInputController();
                    });
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
            }
        }
