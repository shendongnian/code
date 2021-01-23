    //Test attribute class
    [AttributeUsage(AttributeTargets.All)]
    internal class TestAttribute : Attribute
    {
        public int[] Something { get; set; }
    }
    //Using an array initialiser - an array of integers
    [TestAttribute(Something = new int[]{1, 2, 3, 4, 5})]
    public abstract class Something
