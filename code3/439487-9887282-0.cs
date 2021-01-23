    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
    public interface IExceptionHandler
    {
        bool HandleException(System.Exception oex, string policy);
    }
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class ExceptionHandler : IExceptionHandler
    {
        public bool HandleException(System.Exception oex, string policy)
        {
            return ExceptionPolicy.HandleException(oex, policy);
        }
    }
