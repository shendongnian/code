    public interface IHasOutput
    {
        void Output();
    }
    public abstract class OutputBase : IHasOutput
    {
        protected string _name;
        public OutputBase(string name)
        {
            _name = name;
        }
        #region IHasOutput Members
        public virtual void Output()
        {
            Console.WriteLine("The class is: " + this.GetType());
            Console.WriteLine("The name is: " + _name);
        }
        #endregion
        public static IHasOutput Choose(int x, string name)
        {
            switch (x) {
                case 1:
                    return new Articles(name);
                case 2:
                    return new Questionnaire(name);
                default:
                    return null;
            }
        }
    }
    public class Articles : OutputBase
    {
        public Articles(string name)
            : base(name)
        {
        }
    }
    public class Questionnaire : OutputBase
    {
        public Questionnaire(string name)
            : base(name)
        {
        }
    }
