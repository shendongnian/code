    Console.WriteLine(
                    Enumerable
                    .Range(1, 100)
                    .Aggregate(new StringBuilder(), (builder, i)
                        => i % 15 == 0 ? builder.AppendLine("FizzBuzz")
                         : i % 3 == 0 ? builder.AppendLine("Fizz")
                         : i % 5 == 0 ? builder.AppendLine("Buzz")
                         : builder.AppendLine(i.ToString()))
                    .ToString());
