    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            //Read the App.Config file to get the dimensions of the grid
            int dimensions = Convert.ToInt16(ConfigurationManager.AppSettings["dimensions"]);
            //Create the gameboard object with all the buttons needed
            Gameboard gb = new Gameboard(dimensions, this); //Calls the Gameboad constructor method
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
