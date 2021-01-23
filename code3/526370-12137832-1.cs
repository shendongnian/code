    private void button1_Click(object sender, EventArgs e)
    {
        string[] testAnswer = new string[20] { "B", "D", "A", "A", "C", "A", "B", "A", "C", "D", "B", "C", "D", "A", "D", "C", "C", "B", "D", "A" };
        string a = String.Join(", ", testAnswer);
    
    
    
        //Reads text file line by line. Stores in array, each line of the file is an element in the array
        string[] inputAnswer = System.IO.File.ReadAllLines(@"C:\Users\Momo\Desktop\UNI\Software tech\test.txt");
    
        string b = String.Join(", ", inputAnswer);
    
    
        //Increments through array elements in both arrays and checks for matching elements. 
        //Displays in listBox.
        for (int i = 0; i < testAnswer.Length; i++)
        {
            if (testAnswer[i] == inputAnswer[i])
                listBox1.Items.Add(inputAnswer[i]); // or testAnswer[i], as appropriate
            else 
                listBox2.Items.Add(inputAnswer[i]);
            }
    
        int correctAns = listbox1.Items.Count;
        int wringAns = listbox2.Items.Count;
    }
