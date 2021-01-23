                JsonConvert.DeserializeObject<A>("{number:'some thing'}",
                new JsonSerializerSettings
                {
                    Error = (sender, args) =>
                    {
                        Console.WriteLine(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    }
                });
