        public async Task DoProcess()
        {
            try
            {
                await Task.Run(Process1);
                await Task.Run(Process2);
                await Task.Run(Process3);
                SuccessCondition();
            }
            catch (Exception ex)
            {
                ErrorCondition(ex);
            }
        }
