    private async void FadeIn(Form o, int interval = 80) 
    {
        //Object is not fully invisible. Fade it in
        while (o.Opacity < 1.0)
        {
            await Task.Delay(interval);
            o.Opacity += 0.05;
        }
        o.Opacity = 1; //make fully visible       
    }
    private async void FadeOut(Form o, int interval = 80)
    {
        //Object is fully visible. Fade it out
        while (o.Opacity > 0.0)
        {
            await Task.Delay(interval);
            o.Opacity -= 0.05;
        }
        o.Opacity = 0; //make fully invisible       
    }
