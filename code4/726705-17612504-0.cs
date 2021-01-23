     public class Car
        {
            public string Make { get; set; }
            public string this[String name]
            {
                set
                {
                    switch (name)
                    {
                        case "Make":
                            Make = value;
                            break;
                        ...
                    }
                }
            }
        }
