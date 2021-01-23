    List<int> myList = new List<int>();
    for (int i = 1; i < 101; i++)
    {
        myList.Add(i);
    }
                    
    for (int i = 100; i > 0; i--)
    {
        System.Threading.Threading.Sleep(1000);
        myList.RemoveAt(i);
        i -= 1;
        myList.RemoveAt(i);
    }
