    private void pb_pictureBoxTest_MouseDown(object sender, MouseEventArgs e)
    {
        mainMenuVariables.mousedown = true;
        mainMenuVariables.mousedowntime = DateTime.Now;
    }
    private void pb_pictureBoxTest_MouseUp(object sender, MouseEventArgs e)
    {
        mainMenuVariables.mousedown = false;
        var clickDuration = DateTime.Now - mainMenuVariables.mousedowntime;
        if ( clickDuration > TimeSpan.FromSeconds(2))
        {
            // Do 'hold' logic (e.g. open dialog, etc)
        }
        else
        {
            // Do normal click logic (e.g. toggle 'On'/'Off' image)
        }
    }
