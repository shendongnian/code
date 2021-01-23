    public class SpecificResponse : BaseResponse
    {
        public IEnumerable<SpecificResult> Results
        {
            get
            {
                foreach(ResultContent result in Response.Results)
                {
                    SpecificResult newSpecificResult = new SpecificResult();
                    newSpecificResult.Kind = result.Kind;
                    newSpecificResult.Resources = result.Resources;
                    yield return newCategory;
                }
    
                yield break;
            }
        }
    }
