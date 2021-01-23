        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Read the App.Config file to get the dimensions of the grid
                int dimensions = Convert.ToInt16(ConfigurationManager.AppSettings["dimensions"]);
                //Create the gameboard object with all the buttons needed
                Gameboard gb = new Gameboard(dimensions); //Calls the Gameboad constructor method
                //Add buttons to the form
                for (int x = 0; x < gb.buttonArray.Length; x++)
                {
                    this.Controls.Add(gb.buttonArray[x]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
