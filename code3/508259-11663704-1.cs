    do
    {
        names = myfile.ReadLine();
        if (names != null)
        {
            string[] payInfo = names.Split(new[] {' '});
            Console.WriteLine(names);
            // read second line
            var nums = myfile.ReadLine();
            if (nums != null)
            {
                string[] payNums = nums.Split(new[] {' '});
                Console.WriteLine(Decimal.Parse(payNums[0])*
                                  Decimal.Parse(payNums[1]));
            }
        }
    } while (names != null);
