    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public abstract class Plants
        {                                   
            private string the_name;
            private double num_stock;
            private double price_peritem;
            private double total_item_value;
            public string The_Name
            {
                get
                {
                    return the_name;
                }
                protected set
                {
                    the_name = value;
                }
            }
            public double Num_Stock
            {
                get
                {
                    return num_stock;
                }
                protected set
                {
                    num_stock = value;
                }
            }
            public double Price_PerItem
            {
                get
                {
                    return price_peritem;
                }
                protected set
                {
                    price_peritem = value;
                }
            }
            public double Total_Item_Value
            {
                get
                {
                    return Num_Stock * Price_PerItem;
                }               
            }
            public Plants(string new_name, int new_stock, double new_price)
            {
                The_Name = new_name;
                Num_Stock = new_stock;
                Price_PerItem = new_price;
            }
            public override string ToString()
            {
                return string.Format("{0} {1,-25} {2,-25} {3,-25}", The_Name, Num_Stock, Price_PerItem, Total_Item_Value);
            }
            public virtual double Get_Value()
            {
                double s = 0;
                return s;
            }
        }
        public class Berries : Plants
        {
            private string variety;
            private string months;
            public string Variety
            {
                get
                {
                    return variety;
                }
                protected set
                {
                    variety = value;
                }
            }
            
            public string Months
            {
                get
                {
                    return months;
                }
                protected set
                {
                    months = value;
                }
            }
            
            public Berries(string new_name, int new_stock, double new_price, string new_variety, string new_months)
                : base(new_name, new_stock, new_price)
            {
                Variety = new_variety;
                Months = new_months;                
            }
            public override string ToString()
            {
                return string.Format(base.ToString() + " {0} {1}", Variety, Months);
            }
            
            //This is now replaced by simply using the TotalCost property
            //public override double Get_Value()
            //{
            //    return TotalCost;                
            //}
        }
        public void Report()
        {
            //const string format = "{0,-25} {1,-25} {2,-25} {3,-25} {4,-25}";
            Berries berries1 = new Berries("BlueBerries", 12, 5, "AAA Early", "July");
            //now you can modify the result1 string to 
            string result1 = berries1.ToString(); //string.Format(format, berries1 + " ");
            textBox1.AppendText(result1 + Environment.NewLine);
            Berries berries2 = new Berries("Strawberry", 12, 5, "FrostStar", "December");
            string result = berries1.ToString(); //string.Format(format, berries2 + " ");
            textBox1.AppendText(result + Environment.NewLine);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Report();
        }
    }
