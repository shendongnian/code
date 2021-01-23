        class StoryboardWorkerArgs
        {
            public Storyboard StoryBoard { get; set; }
            public object Other { get; set; }
        }
        class BackgroundWorker2 : BackgroundWorker
        {
            public StoryboardWorkerArgs Args { get; set; }
        }
