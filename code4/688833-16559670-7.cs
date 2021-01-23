        void Test()
        {
            Worker worker = new Worker();
            worker.StepOneAction = NewStepOne;
            worker.DoSomeWork();
        }
        Widget NewStepOne(Widget widget)
        {
            // Do some mocking here
            return widget;
        }
