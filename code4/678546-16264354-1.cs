    for (int i = 0, j = 10; i < j; i++)
    {
        if (someCondition)
        {
            j++;
        }
        actions.Add(() => Console.WriteLine(i, j));
    }
