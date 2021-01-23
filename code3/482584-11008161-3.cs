     static void Main()
            {
                MyValidator validator = new MyValidator();
                Console.WriteLine(validator.IsValidate("asdf123")); // This will print false
                Console.WriteLine(validator.IsValidate("999")); //This will print true
                Console.WriteLine(validator.IsValidate("1001")); //This will print false
             }
