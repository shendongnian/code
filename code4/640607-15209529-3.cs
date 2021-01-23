    public class a1 : IA
    {
        public int val { get; set; }
    }
    public class c : IC<b, a1>
    {
        public b b_val { get; set; }
    }
