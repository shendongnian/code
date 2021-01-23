    public interface IImportViewModel
    {
    }
    
    public class TestImportViewModel : IImportViewModel
    {
    }
    
    public interface IValidationResult<out TViewModel> where TViewModel : IImportViewModel
    {
    }
    
    public class ValidationResult<TViewModel> : IValidationResult<TViewModel> where TViewModel : IImportViewModel 
    {
    }
