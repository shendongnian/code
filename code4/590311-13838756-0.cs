    public class CustomControl:Control
    {
    public override void ApplyTemplate()
    {
       _storyBoard=GetTemplateChild("AnimationStoryBoard") as Storyboard;
       _storyBoard.Completed+=OnCompleted;
    }
    public event eventhandler AnimationCompleted;
    
    public void Play()
    {
       _storyBoard.Begin();
    }
    
    private void OnCompleted(object sender, EventArgs args)
    {
        if(AnimationCompleted!=null)
            AnimationCompleted(this,EventArg.Empty);
    }
    }
