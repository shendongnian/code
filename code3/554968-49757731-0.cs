    int age = 12;
    switch (age) 
    {
      case int i when i >=1 && i <= 8:
        System.Console.WriteLine("You are only " + age + " years old. You must be kidding right. Please fill in your *real* age.");
        break;
      case int i when i >=9 && i <= 15:
        System.Console.WriteLine("You are only " + age + " years old. That's too young!");
        break;
      case int i when i >=16 && i <= 100:
        System.Console.WriteLine("You are " + age + " years old. Perfect.");
        break;
      default:
        System.Console.WriteLine("You an old person.");
        break;
    }
