    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml.Linq;
    
    namespace MyProgram
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random random = new Random();
                List<int> randomNumbers= new List<int>();
                for (int i = 0; i < 11; i++)
                {
                    randomNumbers.Add(random.Next(1000));
                }
    
                MessageBox.Show(string.Format("The minimum is: {0}\nThe maximum is: {1}", randomNumbers.Min(), randomNumbers.Max()), "Result");
    
            }
        }
    }
