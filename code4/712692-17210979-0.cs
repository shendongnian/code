    string[] lines = File.ReadAllLines("Customers/" + listBox1.SelectedItem.ToString() + "/" + listBox1.SelectedItem.ToString() + ".txt");
         string[] linesSplitted;
         for (int i = 0; i < 4; i++)
         {
             linesSplitted = lines[i].Split(':');
         }
         TextboxName.Text = linesSplitted[0];
         TextboxAddress.Text = linesSplitted[1];
         TextboxZip.Text = linesSplitted[2];
         TextboxTel.Text = linesSplitted[3];
         TextboxEmail.Text = linesSplitted[4];
