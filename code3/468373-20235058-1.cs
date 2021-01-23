    string dt=DateTime.Now.ToShortTimeString();
    DateTime presenttime=Convert.ToDateTime(dt);
            
    starttime = starttimepicker.ValueString;
    DateTime dtime=Convert.ToDateTime(starttime);
    if (dtime > presenttime)
    {
       MessageBox.Show("Time cannot be greater than System Time. Please Try Again!", "Do not selecting future time", MessageBoxButton.OK);
                starttimepicker.Value = presenttime;
    }
