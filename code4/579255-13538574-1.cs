    using System.Linq;
    
    namespace reverseArray
    {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
                long operations = 0;
                int size;
                int max;
                int[] createArray;
                int[] orderedArray;
                int[] orderedByDescendingArray;    
        
                public int[] CreateArray(int size, int max)
                {
                    var result = new int[size];
                    Random r = new Random();
                    for(int i; i<size; i++)
                    {
                       result[i] = r.Next(max);
                    }
                    return result;
                }
            
            
                private void buttonCreateArray_Click(object sender, EventArgs e)
                {
                    size = Convert.ToInt32(textBoxSize.Text);
                    max = Convert.ToInt32(textBoxMax.Text);
            
                    createArray = CreateArray(size, max);
                    orderedArray = array.OrderBy(a => a);
                    orderedByDescendingArray = array.OrderByDescending(a => a);        
               }
          }
    }
