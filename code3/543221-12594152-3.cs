    private double Display_Results(double velocity, double time, double distance)
                {
                    //Display Results
                    double v=-velocity;
                    double t=-time;
                    double d=-distance;
                    label1.Text = (t + v + d).ToString();
                }
