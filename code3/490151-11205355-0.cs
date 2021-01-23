    public class ParentUtilities
    {
        public static void DoSomething(Parent p)
        {
            CalculateTheMeaningOfTheLife(p);
            
            var a = p as A;
            if (a != null)
            {
                a.Update();
                return;
            }
            var b = p as B;
            if (b != null)
            {
                b.Update();
                return;
            }
            var c = p as C;
            if (c != null)
            {
                c.Update();
                return;
            }
        }
    }
