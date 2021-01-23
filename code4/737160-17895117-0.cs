    private bool IsPrime(int num)
    {
        double num_sqrt = Math.Sqrt(num);
        int num_fl = Convert.ToInt32(Math.Floor(num_sqrt));
        for (int i = 2; i <= num_fl; i++)
        {
            if (num % i == 0)
            {
                return false;
           }
        }
        return true;
    }
    private void bntTestPrime_Click(object sender, EventArgs e)
    {
        int num = Convert.ToInt32(txtInput.Text);
        bool isPrime = IsPrime(num);
        if (isPrime)
            lblResult_prime.Text = "Number " + num + " is Prime.";
        else
            lblResult_prime.Text = "Number " + num + " is not Prime.";
    }
