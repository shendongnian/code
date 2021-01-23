    private void Form1_Load(object sender, EventArgs e)
    {
            MakeReservations();
            DisplayFlights();
            SetupFlights();  // added this line
    }
     private void SetupFlights()
     {
            flightList.Add(flight1);
            flightList.Add(flight2);
     }
