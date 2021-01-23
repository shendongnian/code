    public static void generation(Subject subject)
    {
       Console.WriteLine("Control over Subject  1's personality? ");
       Console.WriteLine("1) None");
       Console.WriteLine("2) Minimal");
       Console.WriteLine("3) Considerable");
       subject.persuasion = Convert.ToInt32(Console.ReadKey());
       switch (subject.persuasion)
       {
           case 1:
               break;
           case 2:
               GenerationFunctions.lightGen();
               break;
           case 3:
               GenerationFunctions.heavyGen();
               break;
           default:
               break;
       }
    }
