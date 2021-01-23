    private void addToArray_Click(object sender, EventArgs e)
    {
    
        //Calculate the new size of the array
        int newLength = arrayOfIntegers.Length + 1;
        //Resize the array
        Array.Resize(ref arrayOfIntegers, newLength);
        //Add the new value to the array
        //Note that this will fail if the textbox does not contain a valid integer.  
        //You can use the Integer.TryParse method to handle this
        arrayOfIntegers[newLength] = Integer.Parse(addArrayTextBox.Text);  
        //Update the text box with the new count
        integerTextBox.Text = newLength.ToString();
    }
