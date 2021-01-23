    public class GenericClass
    {
        public static object GetInstance(Type type)
        {
            var genericType = typeof(GenericClass<>).MakeGenericType(type);
            return Activator.CreateInstance(genericType);
        }
        public static GenericClass<T> GetInstance<T>()
            where T : class
        {
            return new GenericClass<T>();
        }
    }
        [Test]
        public void CanMakeGenericViaReflection_ButItsSlow()
        {
            var timer = new Stopwatch();
            var SC = new SomeClass();
            SC.TypeOfAnotherClass = typeof(OneMoreClass);
            timer.Start();
            for (int x = 0; x < 100000; x++)
            {
                GenericClass.GetInstance(SC.TypeOfAnotherClass);
            }
            timer.Stop();
            Console.WriteLine("With Reflection: " + timer.ElapsedMilliseconds + "ms.");
            timer.Restart();
            for (int x = 0; x < 100000; x++)
            {
                GenericClass.GetInstance<OneMoreClass>();
            }
            timer.Stop();
            Console.WriteLine("Without Reflection: " + timer.ElapsedMilliseconds + "ms.");
        }
