    List<int> list = new List<int>();
    void CheckTextBox()
    {
        if (Convert.ToInt32(DobbelWaarde.Text) == 1)
        {
            if (list.Contains(1))
            {
                Console.WriteLine("1 is allready been chosen");
            }
            else
            {
                list.Add(1);
                Console.WriteLine();
                foreach (int li in list)
                {
                    Console.WriteLine(li);
                    Console.WriteLine("We add 1");
                }
            }
        }
    }
