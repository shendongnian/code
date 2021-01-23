        private sealed class Test
        {
            private readonly string name;
            private readonly int age;
            public Test(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            public string Name
            {
                get
                {
                    return this.name;
                }
            }
            public int Age
            {
                get
                {
                    return this.age;
                }
            }
        }
