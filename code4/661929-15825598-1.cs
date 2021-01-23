    int i = 1;        
    private void addNewRow(object sender, EventArgs e) //all will invoke this generic     method to display the visibility of the next
        {
            ComboBox selectedTest = (ComboBox)sender;
            Canvas thisRow = (Canvas)selectedTest.Parent;
            int index =Int32.Parse(thisRow.Name.Substring(thisRow.Name.Length-1, 1));
            if (thisRow is Canvas && index==i) //needs to ensure that only the previous canvas can invoke the next canvas once selection is done
            {
                i++;
                Canvas newRow = (Canvas)this.FindName("comp" + i);
                newRow.Visibility = Visibility.Visible;
                //add the test Component to a data structure like a list or something
            }
        }
