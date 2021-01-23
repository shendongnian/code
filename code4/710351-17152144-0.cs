     using System;
     using System.Collections.Generic;
     using System.ComponentModel;
     using System.Data;
     using System.Drawing;
     using System.Linq;
     using System.Text;
     using System.Windows.Forms;
     using ZedGraph;
     namespace updateZedGraph
     {
        public partial class Form1 : Form
        {
          public Form1()
          {
            InitializeComponent();
            myPane = zedGraphControl1.GraphPane;
          }
          GraphPane myPane; 
          private void btn_UpdateChart_Click(object sender, EventArgs e)
          {
            // Update x Axis Text
            myPane.XAxis.Title.Text = textBox1.Text;
            // Update x Axis Text
            myPane.YAxis.Title.Text = textBox2.Text;
            // Refresh Chart
            zedGraphControl1.Invalidate();
          }
      }
    }
