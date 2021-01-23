    namespace Program8_4
    {
      public partial class Form1 : Form
      {
        // declare the counter variables in field
        int iNumberOfVowels = 0;
        int iNumberOfConsonants = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            // call the methods in this event
            GetVowels(txtStringInput.Text);
            GetConsonants(txtStringInput.Text);
            // show the result in a label
            lblOutput.Text = "The number of vowels : " + iNumberOfVowels.ToString()+ Environment.NewLine+
                "The number of consonants : " + iNumberOfConsonants.ToString();
            // assign zero the counters to not add the previous number to new number, and start counting from zero again
            iNumberOfVowels = 0;
            iNumberOfConsonants = 0;
        }
        private int GetConsonants(string strFindConsonants)
        {
            // Declare char array to contain consonants letters
            char[] chrConsonants = { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'X',
                'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'x' };
            // loop to get each letter from sentence
            foreach (char Consonants in strFindConsonants)
            {
            // another nested loop to compare each letter with all letters contains in chrConsonants array
                for (int index= 0; index<chrConsonants.Length;index++)
                {
                    // compare each letter with each element in charConsonants array
                    if (Consonants == chrConsonants[index])
                    {
                        // If it is true add one to the counter iNumberOfConsonants
                        iNumberOfConsonants++;
                  }
                }
            }
            // return the value of iNumberOfConsonants
            return iNumberOfConsonants;
        }
       
        private int GetVowels(string strFindVowels)
        {
            // Declare char array to contain vowels letters
            char[] chrVowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O','U' };
            // loop to get each letter from sentence
            foreach (char Vowels in strFindVowels)
            {
                // another nested loop to compare each letter with all letters contains in chrVowels array
                for (int index = 0; index< chrVowels.Length; index++)
                {
                    // compare each letter with each element in chrVowels array
                    if (Vowels == chrVowels[index])
          
                {
                        // If it is true add one to the counter iNumberOfVowels
                        iNumberOfVowels = iNumberOfVowels+1;
                    
                }
                }
            }
            // return the value of iNumberOfVowels
            return iNumberOfVowels;
        }
