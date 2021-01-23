    public class Rectangle
    {
         public int width {get;set;}
         public int height {get;set;}
         public int Area() { return width * height; }
    }
    public class Square : Rectangle
    {
        public override int width
        {
            get { return base.width; }
            set { base.height = value; base.width = value; }
        }
        //... etc ...
    }
    [Test]
    public void Rectangles_area_should_equal_length_times_width()
    {
        Rectangle r = new Square();
        r.height = 10;
        r.width  = 15;
        Assert.That(r.Area() == 150); // Fails
    }
