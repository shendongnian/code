    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    
    namespace WindowsFormsApplication1
    {
       public partial class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
          }
    
          private void Form1_Load(object sender, EventArgs e)
          {
             // With ThreadPool
             ThreadPool.QueueUserWorkItem(DoWork);
          }
    
          private void DoWork(object state)
          {
             // Do Expensive Work
             for (int i = 0; i < 100; i++)
             {
                Thread.Sleep(10);
             }
             System.Diagnostics.Debug.WriteLine("DoWork finished!");
          }
         
       }
    }
