    int answer = 0;
 
    if (input > 0)
    {
        count = 1;
        while (count <= input)
        {
            if (count == 1)
            {
                answer= 1;
                count++;
            }
            else
            {
                answer = count * answer;
                count++;
            }
        }
    }
    else
    {
        MessageBox.Show("Please enter only a positive integer.");
    }
 
    return answer;
}
