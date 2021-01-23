    public class Game
    {
        private const int _dispalyWidth = 42;
    
        public void Start()
        {
            Hero hero = new Hero();
            Monster monster = new Monster();
            Console.WriteLine("You are facing a Monster!");
            Console.ReadKey();
            Console.Clear();
    
            do
            {
                DisplayBattle(hero, monster);
    
                switch (GetChoice())
                {
                    case BattleChoice.Attack:
                        hero.Attack(monster);
                        break;
                    case BattleChoice.Defend:
                        hero.Defend();
                        break;
                    case BattleChoice.Heal:
                        hero.Heal(400);
                        break;
                    default:
                        Console.WriteLine("Monster took a cheap shot!");
                        break;
                }                
    
                if (monster.IsAlive)
                    monster.Attack(hero);
    
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
                Console.Clear();
            }
            while(hero.IsAlive && monster.IsAlive);
            DisplayBattleResult(hero);
            Console.ReadLine();
        }
        private void DisplayBattleResult(Hero hero)
        {
            if (hero.IsAlive)
                Console.WriteLine("You are victorious!");
            else
                Console.WriteLine("You have been defeated :(");
        }
    
        private void DisplayBattle(Hero hero, Monster monster)
        {
            Console.WriteLine(new String('*', _dispalyWidth));
            Console.WriteLine("{0} has {1}hp and the {2} has {3}hp", 
                hero.Name, hero.HitPoints, monster.Name, monster.HitPoints);
            Console.WriteLine(new String('*', _dispalyWidth));
        }
    
        private void DisplayChoices()
        {
            Console.WriteLine(new String('-', _dispalyWidth));
            Console.WriteLine("Please Choose an action:");
            Console.WriteLine("(A)ttack");
            Console.WriteLine("(D)efend");
            Console.WriteLine("(H)eal");
            Console.WriteLine("(F)lee");
            Console.WriteLine(new String('-', _dispalyWidth));
        }
    
        private BattleChoice GetChoice()
        {
            DisplayChoices();
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.A:
                    return BattleChoice.Attack;
                case ConsoleKey.H:
                    return BattleChoice.Heal;
                case ConsoleKey.D:
                    return BattleChoice.Defend;
                default:
                    return BattleChoice.Wait;
            }
        }
    }
