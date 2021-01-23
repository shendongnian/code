            string input = Console.ReadLine();
            bool case1 = input.Contains("north");
            bool case2 = input.Contains("east");
            bool case3 = input.Contains("south");
            bool case4 = input.Contains("west");
            bool case5 = input.Contains("north") && input.Contains("east");
            int CaseId;
            if (case1)
                CaseId = 1;
            else if (case2)
                CaseId = 2;
            else if (case3)
                CaseId = 3;
            else if (case4)
                CaseId = 4;
            else if (case5)
                CaseId = 5;
