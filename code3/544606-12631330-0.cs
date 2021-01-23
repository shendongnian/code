            string univOfCal = "University of California";
            string pascalInst = "Pascal Institute";
            string calUniv = "California University";
            string[] arrayofStrings = new string[] 
            {
            univOfCal, pascalInst, calUniv
            };
            string wordToMatch = "Cal";
            foreach (string i in arrayofStrings)
            {
                    
                if (i.Contains(wordToMatch)){
                 Console.Write(i + "\n");
                }
            }
            Console.ReadLine();
        }
