    List<int> integerList = new List<int>();
    for (int a = 0; a < textBox1.Text.Length; a++)
    {
        integerList.Add(int.Parse(textBox1.Text[a])); // Note: Didn't need the ToString()!
    }
    int b = 8; // Will be 8 for the first multiplication.
    foreach (int item in integerList) // Loop once per input digit.
    {
        listBox1.Items.Add(item * b);
        --b; // So now it will be correct for the next loop iteration.
    }
