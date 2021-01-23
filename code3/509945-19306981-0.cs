    // PieChartForm.Designer.cs
    namespace CSharpPieChart
    {
        partial class PieChartForm
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;
     
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
     
            #region Windows Form Designer generated code
     
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.SuspendLayout();
                //
                // PieChartForm
                //
                this.ClientSize = new System.Drawing.Size(323, 273);
                this.Name = "PieChartForm";
                this.Text = "C# Pie Chart - softwareandfinance.com";
                this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
                this.ResumeLayout(false);
     
            }
     
            #endregion
        }
    }
     
     
    // MainProgram.cs
     
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
     
    namespace CSharpPieChart
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new PieChartForm());
            }
        }
    }
