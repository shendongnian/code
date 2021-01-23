            public void MainFlow()
        {
            Task taskWork = Task.Run(new Action(DoWork));
            //Do other work
            //Then wait for thread finish
            taskWork.Wait();
        }
        private void DoWork()
        {
            //Do work
        }
