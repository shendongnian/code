    public class MathProcessor : BaseProcessing<MathRequest, MathResponse>
    {
        protected override MathResponse DoProcess(MathRequest req)
        {
            return new MathResponse();
        }
    }
