    public enum TestInput
    {
    	None,
    	Bool,
    	Text
    }
    
    public abstract class TestRunnerBase
    {
    	public abstract TestInput TestInput { get; }
    	public bool BoolInput { get; set; }
    	public string TextInput { get; set; }
    	public abstract bool CanRun()
    	public abstract void Run();
    }
    
    public class MainViewModel
    {
    	List<TestRunnerBase> Steps = new List<TestRunnerBase>();
    	public TestRunnerBase CurrentStep {get;set;};
    	
    	public MainViewModel()
    	{
    		//loads the Steps
    		CurrentStep = Steps
    	}
    	
    	public Command RunStepCommand
    	{
    		if (CurrentStep.CanRun())
    		{
    			CurrentStep.Run();
    			CurrentStep = Steps.Next();	//you get the idea
    		}
    	}
    }
