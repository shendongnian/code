    Class MyApp
    {
        private void btnProcessImages_Click(object sender, EventArgs e)
        {
            try 
            {
                double result = Calculate.DevideNumbers(2, 0);
                HandleSuccess(result);
            }
            catch (Exception ex)
            {
                HandleError(ex.Message);
            }
        }
        private void HandleSuccess(double result)
        {
            // Do whatever you do when no errors occur
        }
        private void HandleError(string errorMessage)
        {
            // Do whatever you do when an error occurs... log the exception, etc.
        }
    }
...
    Class Calculate
    {
        public static double DivideNumbers(int num1, int num2)
        {
            result = (double)num1/num2;
            return result;
            // There's no need to catch an exception here if you're ONLY going to re-throw it.
        }        
    }
