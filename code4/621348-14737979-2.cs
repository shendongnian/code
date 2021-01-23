    class EmailSender : IJob {
        static int counter = 0;
        public void Execute(JobExecutionContext context) {
            counter++; // BAD!
        }
    }
