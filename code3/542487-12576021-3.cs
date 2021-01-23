    // Property to GetTime
    public double GetTime
    { 
          get
          {
              // variable to hold time
              double time = double.MinValue;
              
              // Safely parse the text into a double
              if(double.TryParse(tbTime.Text, out time))
              {
                  return time;
              }
              
              // Could just as easily return time here   
              return double.MinValue;
          }
          set
          {
              // Set tbTime
              tbTime.Text = value.ToString();
          }
    }
