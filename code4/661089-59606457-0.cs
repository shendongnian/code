cs
class Hooks
{
    private readonly ScenarioContext _scenarioContext;
    public Hooks(ScenarioContext scenarioContext, TestContext context)
    {
        _scenarioContext = scenarioContext;
    }
    [AfterStep]
    public void AfterStep()
    {
    }
}
