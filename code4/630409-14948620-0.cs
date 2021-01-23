        string userName = "";
        int v1 = 0, v2 = 0, v3 = 0, v4 = 0, v5 = 0;
        int sum = 0;
        float avg;
        float variance;
        Console.WriteLine("Please enter your name:");
        userName = Console.ReadLine();
        Console.WriteLine("Please enter in a number between 10 and 50: ");
        int inputCheck = 0;
        
        for (int i = 0; i < 5; i++)
        {
            inputCheck = Convert.ToInt32(Console.ReadLine());
            while (!(inputCheck < 10 || inputCheck > 50))
            {
                 switch (i)
                {
                    
                    case 1:
                        v1 = inputCheck;
                        break;
                    case 2:
                        v2 = inputCheck;
                        break;
                    case 3:
                        v3 = inputCheck;
                        break;
                    case 4:
                        v4 = inputCheck;
                        break;
                    case 5:
                        v5 = inputCheck;
                        break;
                }
            }
        }
