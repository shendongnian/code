     class Program
    {
        static void Main(string[] args)
        {
            DisplayMenu thisdm = new DisplayMenu();
            ProcessMenu thispm = new ProcessMenu();
            thisdm.displayMenu();
            int menuChoice = thispm.GetChoice();
            thispm.processMenu(menuChoice);
            Console.Read();
        }
        
    }
    class DisplayMenu
    {
        public void displayMenu()
        {
            Console.WriteLine("1 - foo3");
            Console.WriteLine("2 - foo2");
            Console.WriteLine("3 - foo3");
            Console.WriteLine("choose");
        }
    }
    class ProcessMenu
    {
        public int GetChoice()
        {
            String choice = Console.ReadLine();
            int intChoice = Convert.ToInt32(choice);
            while (!Validate(intChoice))
            {
                Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                choice = Console.ReadLine();
                intChoice = Convert.ToInt32(choice);
            }
            return intChoice;
        }
        public void processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    //foo1();
                    break;
                case 2:
                    //foo2();
                    break;
                case 3:
                    //foo3(); ;
                    break;
                default:
                    //Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                    break;
            }
        }
        private int[] forChoices=new int[]{1,2,3};
        private  bool  Validate(int choice)
        {
            if(forChoices.Contains(choice))
            {
                return true;
            }
            return false;
        }
    }
