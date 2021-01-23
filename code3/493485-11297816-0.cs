    for (int i = 0;  i < test.Count; i++)
    {
        Console.WriteLine("i = {0}",i);
        Console.WriteLine("test[i] = {0}", test[i]);
        nameList.Text = String.Join(", ", test[i]) + "\n" + nameList.Text;
    }
