    //List<DataStructure> myList = new LList<DataStructure>();
    //myList.Add(new DataStructure(myTextBox));
    //... populate your list
    
    for (int i = 1; i <= comboBox1.SelectedIndex + 1; i++)
    {
        if (myList[i].Textbox.IsEnabled == false)
        {
            myList[i].Lenght = 0;
        }
        else if (myList[i].Textbox.Text == "")
        {
            throw new Exception(myList[i].Textbox.Name +  " must have a value");
        }
        else if (!double.TryParse(myList[i].Textbox.Text, out myList[i].Lenght))
        {
            throw new Exception(myList[i].Textbox.Name + " must be numerical");
        }
    }
