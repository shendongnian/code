        {
            int total = 0;
            double Average;
            for (int index = 0; index < iArray.Length;
                index++)
           {
                total += iArray[index];
           }
            Average = (double) total / iArray.Length;
            return Average;
        }
        private int Highest(int[] iArray)
        {
            int highest = iArray[0];
            for (int index = 1; index < iArray.Length; index++)
            {
                if (iArray[index] > highest)
                {
                    highest = iArray[index];
                }
            }
            return highest;
        }
        private int Lowest(int[] iArray)
        {
            int lowest = iArray[0];
            
            for (int index = 1; index < iArray.Length; index++)
            {
                if (iArray[index] < lowest)
                {
                    lowest = iArray[index];
                }
            }
            return lowest;
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                const int SIZE = 5;
                int[] Scores = new int [SIZE];
                int index = 0;
                int highestScore;
                int lowestScore;
                double averageScore;
                StreamReader inputFile;
                inputFile = File.OpenText("C:\\Users\\Asus\\Desktop\\TestScores.txt");
                while (!inputFile.EndOfStream && index < Scores.Length)
                {
                    Scores[index] = int.Parse(inputFile.ReadLine());
                    index++;
                }
                inputFile.Close();
                foreach (int value in Scores)
                {
                    listBox1.Items.Add(value);
                }
                highestScore = Highest(Scores);
                lowestScore = Lowest(Scores);
                averageScore = Average(Scores);
                textBox1.Text = highestScore.ToString();
                textBox2.Text = lowestScore.ToString();
                textBox3.Text = averageScore.ToString("n1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}
