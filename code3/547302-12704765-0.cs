    public partial class Form1: Form
        {
            public Form1()
            {
                InitializeComponent();
                this.Load += new EventHandler(Form1_Load);
            }
    
            void Form1_Load(object sender, EventArgs e)
            {
                Test();
            }
    
            static int Function1(int parameter1, int parameter2)
            {
                return (parameter1 + parameter2);
            }
    
            static void Test()
            {
                int[] nums = Enumerable.Range(0, 1000000).ToArray();
                long total = 0;
    
                // Use type parameter to make subtotal a long, not an int
                Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
                {
                    subtotal += (nums[j] + Function1(1,2));
                    return subtotal;
                },
                    (x) => Interlocked.Add(ref total, x)
                );
    
                MessageBox.Show(string.Format("The total is {0}", total));
            }
        }
