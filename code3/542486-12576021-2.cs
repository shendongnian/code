    private double CalculateVelocity()
    {
        double distance = 0;
        double time = 0;
        
        if(double.TryParse(tbDistance.Text, out distance) &&
           double.TryParse(tbTime.Text, out time))
        {
            return distance/time;
        }
    
        return 0.0;
    }
    private double GetTime()
    {
        //Get Time
    }
    private double CalculateDistance(double velocity, double time)
    {
        //Calculate Distance
    }
    private double DisplayResults(double velocity, double time, double distance)
    {
        //Display Results
    }
    private double ClearTextboxes()
    {
        //Clear textboxes
    }
    private void button1_Click(object sender, EventArgs e)
    {
        //You get the idea
    }
