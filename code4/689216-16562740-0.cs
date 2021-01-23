    int x = int.Parse(textBox1.Text); 
    List<int> integerList = new List<int>();
    x = Math.Abs(x);
    while (x >= 1)
    {
         integerList.Add(x % 10);
         x = x / 10;
    }
    integerList.Reverse();
