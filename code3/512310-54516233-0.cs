    public static void FizzBuzz() {
        StringBuilder sb = new StringBuilder();
    
	    for (int i = 1; i <= 100; i++) {    
	        if (i % 3 == 0 && i % 5 == 0) {
                sb.AppendLine($"{i} - FizzBuzz");
            } else if (i % 3 == 0) {
                sb.AppendLine($"{i} - Fizz");
            } else if (i % 5 == 0) {
                sb.AppendLine($"{i} - Buzz");
            } else {
                sb.AppendLine($"{i}");
            }
        }
        Console.WriteLine(sb);
    }
