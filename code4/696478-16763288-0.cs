    int sum=0;
    for (int i = 1; i <= 1000; i++)
                if (i % 21 == 0 || i % 5 == 0)
                    {
                        listBox2.Items.Add(i);
                        sum+=i;
                    }
             textBox2.Text = sum.ToString();
