    do
    {
        name = myfile.ReadLine();
        if (name != null)
        {
            // read second line
            var nums = myfile.ReadLine();
            if (nums != null)
            {
                string[] payNums = nums.Split(new[] {' '});
                Console.WriteLine("{0}: {1}", 
                                  name,
                                  Decimal.Parse(payNums[0])
                                  * Decimal.Parse(payNums[1]));
            }
        }
    } while (name != null);
