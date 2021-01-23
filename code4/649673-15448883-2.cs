    //int counter = 0; may as well move inside as it looks to be localised
    private void btnDisplay_Click(object sender, EventArgs e)
    {
        using(StreamReader myReader = new StreamReader("StudentRecords.txt"))
        {
            int counter = 0;
             while (myReader.EndOfStream)
             {
                 string[] storageArray = myReader.ReadLine().Split('#');
                  switch(storageArray[0])
                  {
                  case "S":
                       lstDisplay.Items.Add("");
                       lstDisplay.Items.Add("Student Name: " + storageArray[1]);
                       lstDisplay.Items.Add("Student Number: " +storageArray[2]);
                       lstDisplay.Items.Add("Attendance: " + storageArray[5]);
                       lstDisplay.Items.Add("Modules: ");
                       counter++;
                        break;
                   case "M":
                         lstDisplay.Items.Add(storageArray[1]);
                        break;
                  default:
                        break;
                 }
             }
        }
        //label to be used to display the number of students
        lblnoOfStudents.Text = counter.ToString();
        }
    }
