        void mainViewport_MouseUp(object sender, MouseButtonEventArgs e)
        {
        Point location = e.GetPosition(mainViewport);
        ModelVisual3D result = GetHitResult(location);
        if(result == null)
        {
        return;
        }
        //Do Stuff Here
        }
        void mainViewport_MouseDown(object sender, MouseButtonEventArgs e)
        {
        Point location = e.GetPosition(mainViewport);
        ModelVisual3D result = GetHitResult(location);
        if(result == null)
        {
        return;
        }
        //Do Stuff Here
        }
