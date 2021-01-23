    class Program
    {
        private static Expression<Func<T, string>> GetValueFromFoo<T>(Func<T, Foo> getFoo)
        {
            return t => getFoo(t).Bar.Value;
        }
        static void Main()
        {
            Expression<Func<Model, string>> getValueFromBar = GetValueFromFoo<Model>(m => m.SubModel.Foo);
            // test it worked
            var func = getValueFromBar.Compile();
            Model test = new Model
            {
                SubModel = new SubModel
                {
                    Foo = new Foo
                    {
                        Bar = new Bar { Value = "abc" }
                    }
                }
            };
            Console.WriteLine(func(test)); // "abc"
        }
    }
