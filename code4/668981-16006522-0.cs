    public void Sum(int num1, int num2)
    {
        addLabel.Text = string.Format("The sum of the numbers is {0}.", num1 + num2);
    }
    public void Difference(int num1, int num2)
    {
        differenceLabel.Text = string.Format("The difference of the numbers is {0}.", num1 - num2);
    }
    public void Product(int num1, int num2)
    {
        double multiply = num1 * num2;
        productLabel.Text = string.Format("The product of the numbers is {0}.", multiply);
    }
