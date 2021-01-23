    using System.Windows;
    public class Client : DependencyObject
    {
        public string Name { get; set; }
        public Client(string name)
        {
            Name = name;
        }
        //add to descendant to use
        //public double Weight
        //{
        //    get { return (double)GetValue(WeightProperty); }
        //    set { SetValue(WeightProperty, value); }
        //}
        public static readonly DependencyProperty WeightProperty =
            DependencyProperty.Register("Weight", typeof(double), typeof(Client), new PropertyMetadata());
        //add to descendant to use
        //public double Height
        //{
        //    get { return (double)GetValue(HeightProperty); }
        //    set { SetValue(HeightProperty, value); }
        //}
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(double), typeof(Client), new PropertyMetadata());
    }
    public interface IWeight
    {
        double Weight { get; set; }
    }
    public interface IHeight
    {
        double Height { get; set; }
    }
    public class ClientA : Client, IWeight
    {
        public double Weight
        {
            get { return (double)GetValue(WeightProperty); }
            set { SetValue(WeightProperty, value); }
        }
        public ClientA(string name, double weight)
            : base(name)
        {
            Weight = weight;
        }
    }
    public class ClientB : Client, IHeight
    {
        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }
        public ClientB(string name, double height)
            : base(name)
        {
            Height = height;
        }
    }
    public class ClientC : Client, IHeight, IWeight
    {
        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }
        public double Weight
        {
            get { return (double)GetValue(WeightProperty); }
            set { SetValue(WeightProperty, value); }
        }
        public ClientC(string name, double weight, double height)
            : base(name)
        {
            Weight = weight;
            Height = height;
        }
    }
    public static class ClientExt
    {
        public static double HeightInches(this IHeight client)
        {
            return client.Height * 39.3700787;
        }
        public static double WeightPounds(this IWeight client)
        {
            return client.Weight * 2.20462262;
        }
    }
