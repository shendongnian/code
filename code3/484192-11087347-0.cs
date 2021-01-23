        private void Form1_Load(object sender, EventArgs e)
        { 
         listBox1.Items.AddRange(Enum.GetNames(typeof(Microsoft.Office.Core.XlChartType)));
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Microsoft.Office.Core.XlChartType enumVal = (Microsoft.Office.Core.XlChartType)Enum.Parse(typeof(Microsoft.Office.Core.XlChartType), listBox1.SelectedItem.ToString());
                Globals.ThisAddIn.Application.Selection.InlineShapes.AddChart(enumVal);
            }
        }
