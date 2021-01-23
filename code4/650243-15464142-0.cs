    private void CalcStayChargesButton_Click(object sender, EventArgs e)
    {
         int NumberOfDays; //Create the variable
         //try to parse DaysInHosputalChargesTextBox.Text
         if (!(int.TryParse(DaysInHospitalChargesTextBox.Text, out NumberOfDays))) 
         {
             // "!" means the parsing was not ok. So the user should reenter the number     
             MessageBox.Show("Please enter a whole number.");
         }
         else
         {
             //some code to do if the parsing was successful. 
         }
    }
