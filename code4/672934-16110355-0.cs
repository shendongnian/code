    public class SimpleExample
    {
        Func<int> func;
        public SimpleExample(Func<int> func)
        {
            this.func = func;
        }
        public void DisplayValue()
        {
            print(func());
        }
    }
    public class RandomClass
    {
        int myValue = 10;
        SimpleExample s;
        public RandomClass()
        {
            s = new SimpleExample(() => myValue);
        }
        public void WorkWithValue()
        {
            myValue++;
        }
        public void Display()
        {
            print(foo);
            print(bar);
            s.DisplayValue();
        }
    }
