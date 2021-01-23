    private bool[] downsampled;
    private Dictionary<char, List<bool[]>> letterData = new Dictionary<Char, List<bool[]>>();
    //
    //     Your Code
    //
    if (Result != null)
    {
        Result = Result.ToUpper();
        if (Result.Length == 0)
        {
            MessageBox.Show("Please enter a character.");
        }
        else if (Result.Length < 1)
        {
            MessageBox.Show("Please enter only a single character.");
        }
        else
        {
            if (this.letterData.ContainsKey(Result[0]))
            {
                this.letterData[Result[0]].Add(this.downsampled);
            }
            else
            {
                this.letterData.Add(Result[0], new List<bool[]>() { this.downsampled });
            }
            this.letters.Items.Add(Result);            
            this.ClearEntry();
        }
    }
