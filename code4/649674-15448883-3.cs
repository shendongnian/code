    //int counter = 0; may as well move inside as it looks to be localised
    private void btnDisplay_Click(object sender, EventArgs e)
    {
        StreamReader myReader = new StreamReader("StudentRecords.txt");
        int counter = 0;
        while (myReader.EndOfStream == false)
        {
            string[] storageArray = myReader.ReadLine().Split('#');
            if (storageArray[0] = "S")
            {
                lstDisplay.Items.Add("");
                lstDisplay.Items.Add("Student Name: " + storageArray[1]);
                lstDisplay.Items.Add("Student Number: " +storageArray[2]);
                lstDisplay.Items.Add("Attendance: " + storageArray[5]);
                lstDisplay.Items.Add("Modules: ");
                counter++;
            }
            else if (storageArray[0] == "M")
            {
                lstDisplay.Items.Add(storageArray[1]);
            }
        }
        //label to be used to display the number of students
        lblnoOfStudents.Text = counter.ToString();
        myReader.Close();
    }
