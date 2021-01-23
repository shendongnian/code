      public Form1()
      {
         InitializeComponent();
         fromList.Items.Add(new CentimeterFromMillimeterConverter());
         toList.Items.Add(new CentimeterToMillimeterConverter());
      }
      void Convert(double amount)
      {
         var from = (FromMillimeterConverter) fromList.SelectedItem;
         var to = (FromMillimeterConverter) toList.SelectedItem;
         to.Convert(from.Convert(amount));
      }
    public abstract class ToMillimeterConverter
    {
      public abstract double Convert(double unit);
      public override string ToString()
      {
         return GetType().Name.Replace("ToMillimeterConverter", "");
      }
    }
    public class CentimeterToMillimeterConverter : ToMillimeterConverter
    {
      public override double Convert(double centimeters)
      {
         return 10 * centimeters;
      }
    }
    public abstract class FromMillimeterConverter
    {
      public abstract double Convert(double unit);
      public override string ToString()
      {
         return GetType().Name.Replace("FromMillimeterConverter", "");
      }
    }
    public class CentimeterFromMillimeterConverter : FromMillimeterConverter
    {
      public override double Convert(double centimeters)
      {
         return centimeters / 10;
      }
    }
