    using System;
     using System.Collections.Generic;
     using System.ComponentModel;
     using System.Data;
     using System.Drawing;
     using System.Linq;
     using System.Text;
     using System.Windows.Forms;
 
    namespace WindowsFormsApplication11 
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
    public  int points=0;
    
        private void Form1_Load(object sender, EventArgs e)
        {
    
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        
            int userInput = int.Parse(textBox1.Text);
    
            if (userInput == 0)
    
            {
                points = 5; 
            }
    
            if (userInput == 1)
    
            { 
                points = 10;
            }
    
            if (userInput == 2)
    
            {
                points = 20;
            } 
    
            if (userInput ==3)
    
            {
                points = 30;
            }
    
            else
    
            {
                points = 40;
    
            }
    
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show = ("You have been awarded" + points.ToString() + "points");
        } 
    
    
    
        private void label1_Click(object sender, EventArgs e)
        {
    
        }
     }
    }
