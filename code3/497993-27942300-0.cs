    public class CalculatorController : ApiController
    {
        [HttpGet]
        [ActionName("Add")]
        public string Add(int num1 = 1, int num2 = 1, int timeDelay = 1)
        {
            Thread.Sleep(1000 * timeDelay);
            return string.Format("Add = {0}", num1 + num2);
        }
        [HttpGet]
        [ActionName("Sub")]
        public string Sub(int num1 = 1, int num2 = 1, int timeDelay = 1)
        {
            Thread.Sleep(1000 * timeDelay);
            return string.Format("Subtract result = {0}", num1 - num2);
        }
        [HttpGet]
        [ActionName("Mul")]
        public string Mul(int num1 = 1, int num2 = 1, int timeDelay = 1)
        {
            Thread.Sleep(1000 * timeDelay);
            return string.Format("Multiplication result = {0}", num1 * num2);
        }
        [HttpGet]
        [ActionName("Div")]
        public string Div(int num1 = 1, int num2 = 1, int timeDelay = 1)
        {
            Thread.Sleep(1000 * timeDelay);
            return string.Format("Division result = {0}", num1 / num2);
        }
    }
