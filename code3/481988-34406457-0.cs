    public async static Task RunStoryboard(Storyboard Story)
    {
        Story.Begin();
        while (Story.GetCurrentState() == ClockState.Active && Story.GetCurrentTime() < Story.Duration)
        {
            await Task.Delay(100);
        }
    }
 
