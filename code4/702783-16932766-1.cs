    var numbers = new int[5,5] { { 1, 2, 3, 4, 5 }, 
    { 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5 }, { 2, 3, 4, 5, 6 }, { 1, 2, 3, 4, 5 }};
    
    private void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                list_Matrix.Items.Add(numbers[i,j].To String());
            }
        }
    }
