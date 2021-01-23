    public class Response<T>
    {
        public int num1 { get; set; }
        public int num2 { get; set; }
        public T[] food { get; set; }
    }
    
    Response<Drink> response = new Response<Drink>
        {
            num1= 7, num2= 2, food = new Drink[] 
            { new Drink{Id=1, Name="Orange"}, new Drink{Id=2, Name="Apple"}}
        };
    
    Response<Snack> response = new Response<Snack>
        {
            num1= 7, num2= 2, food = new Snack[] 
            { new Snack{Id=1, Name="Orange"}, new Snack{Id=2, Name="Apple"}}
        };
