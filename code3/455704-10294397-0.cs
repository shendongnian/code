    class Step1Result {}
    class Step2AResult
    {
        public Step2AResult(Step1Result result) {}
    }
    class Step2BResult
    {
        public Step2BResult(Step1Result result) {}
    }
    class FinalResult 
    {
        public FinalResult(Step2AResult step2AResult, Step2BResult step2BResult) {}
    }
        public Task<FinalResult> RunStepsAsync()
        {
            var task1 = Task<Step1Result>.Factory.StartNew(() => new Step1Result());
            // Use the result of step 1 in steps 2A and 2B
            var task2A = task1.ContinueWith(t1 => new Step2AResult(t1.Result));
            var task2B = task1.ContinueWith(t1 => new Step2BResult(t1.Result));
            // Now merge the results of steps 2A and 2B in step 3
            return Task <FinalResult>
                .Factory
                .ContinueWhenAll(new Task[] { task2A, task2B }, tasks => new FinalResult(task2A.Result, task2B.Result));
        }
