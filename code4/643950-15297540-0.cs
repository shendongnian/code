    public class FuncResultInfo
        {
            public bool ExecutionSuccess { get; set; }
            public string ErrorCode { get; set; }
            public ErrorEnum Error { get; set; }
            public string CustomErrorMessage { get; set; }
    
            public FuncResultInfo()
            {
                this.ExecutionSuccess = true;
            }
    
            public enum ErrorEnum
            {
                ErrorFoo,
                ErrorBar,
            }
        }
    
        public static class Factory
        {
            public static int GetNewestItemId(out FuncResultInfo funcResInfo)
            {
                var i = 0;
                funcResInfo = new FuncResultInfo();
    
                if (true) // whatever you are doing to decide if the function fails
                {
                    funcResInfo.Error = FuncResultInfo.ErrorEnum.ErrorFoo;
                    funcResInfo.ErrorCode = "234";
                    funcResInfo.CustomErrorMessage = "Er mah gawds, it done blewed up!";
                }
                else
                {
                    i = 5; // whatever.
                }
    
                return i;
            }
        }
