    using System;
    using System.Windows.Forms;
    using MathWorks.MATLAB.NET.Arrays;
    using calculator;
    namespace DemoCalculator
    {
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var calc= new demo();            
            MessageBox.Show(calc.calculator((MWCharArray)textBox1.Text)[1].ToString());
        }
        
    }
 }
