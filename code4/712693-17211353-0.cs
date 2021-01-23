    string[] lines = File.ReadAllLines("Customers/" + listBox1.SelectedItem.ToString() + "/" + listBox1.SelectedItem.ToString() + ".txt");
    
    
     List<string[]> data  = new List<string[]>(); 
             for (int i = 0; i < 4; i++)
             {
                data.Add(lines[i].Split(':'));
             }
    
    //Retrive array from list and value from array and set to text box
    
             TextboxName.Text = linesSplitted[0];
             TextboxAddress.Text = linesSplitted[1];
             TextboxZip.Text = linesSplitted[2];
             TextboxTel.Text = linesSplitted[3];
             TextboxEmail.Text = linesSplitted[4];
