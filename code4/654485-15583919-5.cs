    interface IPolygon
    {
        double CalculateArea()
    }
    class Rectangle : IPolygon
    {
        double Width { get; set; }
        double Height { get; set; }
        double CalculateArea()
        {
            return this.Width * this.Height;
        }
    }
    class Triangle : IPolygon
    {
        double Base { get; set; }
        double Height { get; set; }
        double CalculateArea()
        {
            return 0.5 * this.Base * this.Height;
        }
    }
