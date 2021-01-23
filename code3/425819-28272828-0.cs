    [CodedUITest]
    public class ProjectTabTests : CodedUIFunctionalTestBase
    { 
        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
        }
        [TestMethod]
        public void Test()
        {
        }
    }
    [TestClass] // this broke everything! remove it!
    public class CodedUIFunctionalTestBase
    {
        public virtual void SetUp()
        {
            KillProcess(Constanst.ProcessName);
            
            Playback.PlaybackSettings.SmartMatchOptions = SmartMatchOptions.None;
            Playback.PlaybackSettings.LoggerOverrideState = HtmlLoggerState.AllActionSnapshot; // here I got internal NullReferenceException
            Playback.PlaybackSettings.SearchTimeout = 10000;
            Playback.PlaybackSettings.WaitForReadyTimeout = 10000;
            Playback.PlaybackSettings.ThinkTimeMultiplier = 1;
            Playback.PlaybackSettings.MaximumRetryCount = 3;
            Application = ApplicationUnderTest.Launch(Constants.Application);
        }
    }
