        static void Main()
        {
            var generator = new SampleScriptGenerator(new JavascriptSerializer());
            generator.Script += Console.Write; // bind to console output here
            var queryProvider = new SampleQueryProvider
                                    {
                                        {
                                            1, // user with id 1
                                            new List<IQuery>
                                                {
                                                    new ReplaceQuery("<name>", "frenchie"),
                                                    new GreetingToQuery("bonjour", "the universe"),
                                                    new LineEndingQuery()
                                                }
                                            },
                                        {
                                            2, // user with id 2
                                            new List<IQuery>
                                                {
                                                    new ReplaceQuery("<name>", "stegi"),
                                                    new GreetingToQuery("hello", "the world"),
                                                    new LineEndingQuery()
                                                }
                                            }
                                    };
            var data1 = new Data {Content = "My name is <name>."};
            var data2 = new Data {Content = "I say hello to "};
            var data3 = new Data {Content = "I say bonjour to "};
            var data4 = new Data {Content = "."};
            // you cold combine data and user query execution into lists and loops, too
            generator.Generate(data1, queryProvider.GetQuerysForUser(1));
            generator.Generate(data2, queryProvider.GetQuerysForUser(1));
            generator.Generate(data3, queryProvider.GetQuerysForUser(1));
            generator.Generate(data4, queryProvider.GetQuerysForUser(1));
            generator.Generate(data1, queryProvider.GetQuerysForUser(2));
            generator.Generate(data2, queryProvider.GetQuerysForUser(2));
            generator.Generate(data3, queryProvider.GetQuerysForUser(2));
            generator.Generate(data4, queryProvider.GetQuerysForUser(2));
            Console.ReadKey();
        }
    }
