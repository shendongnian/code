     List<int> list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
    
     int number = Convert.ToInt32(DobbelWaarde.Text);
    
            if ( number == 1)
            {
                if (list.Contains(1))
                {
                    Console.WriteLine(number + " is allready been chosen");
                }
                else
                {
                    list.Add(number );
                    Console.WriteLine();
                    foreach (int li in list)
                    {
                        Console.WriteLine(li);
                        Console.WriteLine("We add " + number);
                    }
                }
            }
