        private void button1_Click(object sender, EventArgs e)
        {
            // Settings to generate a New TextBox
            TextBox txt = new TextBox();   // Create the Variable for TextBox
            txt.Name = "MyTextBoxID";      // Identify your new TextBox
            
            // Create Variables to Define "X" and "Y" Locations
            var txtLocX = txt.Location.X;
            var txtLocY = txt.Location.Y;
            //Set your TextBox Location Here
            txtLocX = 103;
            txtLocY = 74;
            // This adds a new TextBox
            this.Controls.Add(txt);
            // Now do the same for Labels
            // Settings to generate a New Label
            Label lbl = new Label();   // Create the Variable for Label
            lbl.Name = "MyNewLabelID"; // Identify your new Label
            // Create Variables to Define "X" and "Y" Locations
            var lblLocX = lbl.Location.X;
            var lblLoxY = lbl.Location.Y;
            //Set your Label Location Here
            lblLocX = 34;
            lblLoxY = 77;
            // Adds a new Label
            this.Controls.Add(lbl);
        }
    }
