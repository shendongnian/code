    if (myval % 3 == 0)
    {
        listBox1.Items.Add("fizz");
    }
    else if (myval % 5 == 0)
    {
        listBox1.Items.Add("buzz");
    }
    else if (myval % 15 == 0)
    {
        listBox1.Items.Add("fizzbuzz"); // for multiples of both 3 and 5  
    }
    else
    {
        listBox1.Items.Add(myval);
    }
