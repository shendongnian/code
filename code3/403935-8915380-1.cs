    class When_I_Pass_A_Valid_Dictionary_I_Should_See_My_List_Output_To_My_Writer
    {
        static void Main(string[] args)
        {
            //Arrange
            //dummy data
            var list = new Dictionary<string, int>()
            {
                {"a", 100},
                {"b", 200},
                {"c", 300},
                {"d", 400}
            };
    
            using (StringWriter sw = new StringWriter())
            {
                //Act
                //var repo = new CodeUnderTest.Repository(Console.Out, new CodeUnderTest.MessageBoxFake());
                var repo = new CodeUnderTest.Repository(sw, new CodeUnderTest.MessageBoxFake());
                repo.WriteTop20Tags(list);
    
                //Assert
                //expect my writer has contents
                if (sw.ToString().Length > 0)
                {
                    Console.WriteLine("success");
                }
                else
                {
                    Console.WriteLine("failed -- string writer was empty!");
                }
            }
    
            Console.ReadLine();
        }
    }
