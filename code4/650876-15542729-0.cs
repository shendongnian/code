    public partial class UIMap
    {
        public ApplicationUnderTest _aut { get; set; }
        public void AUT_Open()
        {
             string AUTExecutable = ConfigurationManager.AppSettings["AUTExecutable"];
             _aut = ApplicationUnderTest.Launch(AUTExecutable );
             _aut.CloseOnPlaybackCleanup = false;
        }
        ...
    }
