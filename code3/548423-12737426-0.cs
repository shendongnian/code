    private void button1_Click(object sender, EventArgs e)
    {
        //Starting Values
        var paddingLength = 7;
        var paddingCharacter = '-';
        var value = "ABCDE";
    
        //Create starting string value
        var startValue = value.PadLeft(paddingLength, paddingCharacter);
    
        //Create Char Array of string
        var charArray = startValue.ToCharArray();
    
        //New List
        var values = new List<String>();
    
        //Shifter and StartingShifter
        Int32 shifter;
        Int32 startingShifter;
        shifter = startingShifter = (paddingLength - value.Length) - 1;
    
        //Max Length of the Char array
        var maxLength = charArray.Length-1;
    
        //Total loops the for loop need to do
        var totalLoops = value.Length * (paddingLength - value.Length)-1;
    
        //Loop
        for (int i = 0; i <= totalLoops; i++)
        {
            //Swap the Characters
            SwapChar(charArray, shifter, shifter + 1);
    
            //Add value into list
            values.Add(new String(charArray));
    
            //Go on shifting or go to next character
            if (shifter + 1 == maxLength)
            {
                //Change the Max
                maxLength--;
    
                //Next -
                shifter = startingShifter = startingShifter - 1;
    
                ////FailSafe
                //if (shifter < 0)
                //{
                //    break;
                //}
            }
            else
            {
                //Next Array Value
                shifter++;
            }
        }
        //Set value in textbox
        textBox1.Text = String.Join(Environment.NewLine, values.ToArray());
    }
    
    private static void SwapChar(Char[] array, int position1, int position2)
    {
        //
        // Swaps elements in an array. Doesn't need to return a reference.
        //
        Char temp = array[position1]; // Copy the first position's element
        array[position1] = array[position2]; // Assign to the second element
        array[position2] = temp; // Assign to the first element
    }
