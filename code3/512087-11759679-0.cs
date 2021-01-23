    public abstract class AbstractEmployee
    {
        ...
        public abstract bool IsActiveAccountant { get; set; }
        public abstract bool IsActiveProgrammer { get; set; }
        public bool IsActive() { get { return bitwise or of all roles; } }
    }
    public class NewEmployee : AbstractEmployee
    {
        ...
        public override bool IsActiveAccountant { get; set; }
        public override bool IsActiveProgrammer { get; set; }
    }
    public class Programmer : AbstractEmployee
    {
        ...
        public override bool IsActiveAccountant { get; set; }
        public override bool IsActiveProgrammer { get; set; }
    }
