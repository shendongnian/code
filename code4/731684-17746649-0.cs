    public interface IStepViewModelBuilderFactory
    {
        IStepModelBuilder<T> Create<T>(T stepViewModel) where T : IStepViewModel;
        //... rest of the class definition
    }
    
    public class SpecificViewModelBuilder : IStepModelBuilder<SpecificStepViewModel>
    {
    }
