        void Test()
        {
            Worker worker = new Worker();
            worker.StepOneAction = NewStepOne;
            worker.DoWork();
        }
        Widget NewStepOne(Widget widget)
        {
            // Do some mocking here
            return widget;
        }
