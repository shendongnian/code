    public class MyPoco
    {
        public static implicit operator MyPoco(MyDTO o)
        {
            if (o == null) return null;
			return new MyPoco {
				SomeAmount = Convert.ToDecimal(o.SomeAmount),
				SomeBool   = Equals("Y", o.SomeBool     ),
				Sub1       = o.Sub1,
				Sub2       = o.Sub2,
			};
        }
        public static implicit operator MyDTO(MyPoco o)
        {
            if (o == null) return null;
			return new MyDTO {
				SomeAmount = o.SomeAmount.ToString(),
				SomeBool   = o.SomeBool     ? "Y":"N",
				Sub1       = o.Sub1,
				Sub2       = o.Sub2,
			};
        }
        public decimal SomeAmount   { get; set; }
        public bool SomeBool        { get; set; }
        public MySubPoco1 Sub1      { get; set; }
        public MySubPoco2 Sub2      { get; set; }
    }
