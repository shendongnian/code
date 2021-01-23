    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
       public partial class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
          }
      void Button1Click(object sender, System.EventArgs e)
      {
         Task one = new Task(() => DoSomething());
         Task two = new Task(() => DoSomethingElse());
         Task three = new Task(() => DoEvenMore());
         one.Start();
         two.Start();
         three.Start();
      }
      void DoSomething()
      {
         if (InvokeRequired) Invoke((MethodInvoker)delegate { DoSomething(); });
         else label1.Text = "One started";
      }
      void DoSomethingElse()
      {
         if (InvokeRequired) Invoke((MethodInvoker)delegate { DoSomethingElse(); });
         else label1.Text += "Two started";
      }
      void DoEvenMore()
      {
         if (InvokeRequired) Invoke((MethodInvoker)delegate { DoEvenMore(); });
         else label1.Text += "Three started";
      }
       }
    }
