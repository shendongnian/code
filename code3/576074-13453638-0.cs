    public abstract class AbstractQuery
    {
         AbstractQuery Create(dynamic result);
    }
    public class SpecificQuery1 : AbstractQuery
    {
        new public SpecificQuery1 Create(dynamic result)
        {
           ...
        }
    }
    public void ProcessItem(dynamic dynamicResult)
    {
        var staticResult = _query.Create(dynamicResult);
    }
