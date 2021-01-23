    private async void Fade(Form o, int interval = 100)
    {           
        if (o.Opacity != 1.0)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);                    
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible
        }
        else
        {
            //Object is fully visible. Fade it out
            while (o.Opacity > 0.0)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.05;
            }
            o.Opacity = 0; //make fully invisible
        }
    }
