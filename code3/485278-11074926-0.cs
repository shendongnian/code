     private void button1_Click(object sender, EventArgs e) 
     { 
        chart1 = new Chart();
        chart1.ChartAreas.Add("chart"); 
        chart1.ChartAreas["chart"].AxisX.Minimum = 0; 
        chart1.ChartAreas["chart"].AxisX.Maximum = 20; 
        chart1.ChartAreas["chart"].AxisX.Interval = 1; 
 
        chart1.ChartAreas["chart"].AxisY.Minimum = 0; 
        chart1.ChartAreas["chart"].AxisY.Maximum = 100; 
        chart1.ChartAreas["chart"].AxisY.Interval = 5; 
 
        chart1.Series.Add("xxx"); 
        chart1.Series.Add("yyy"); 
 
        chart1.Series["xxx"].Color = Color.Black; 
        chart1.Series["yyy"].Color = Color.Red; 
 
        chart1.Series["xxx"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line; 
        chart1.Series["yyy"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line; 
 
        chart1.Series["xxx"].Points.AddXY(comboBox1.Text, comboBox4.Text); 
        chart1.Series["yyy"].Points.AddXY(comboBox1.Text, comboBox4.Text); 
 
        chart1.Series["xxx"].Points.AddXY(comboBox2.Text, comboBox5.Text); 
        chart1.Series["yyy"].Points.AddXY(comboBox1.Text, comboBox4.Text); 
 
        chart1.Series["xxx"].Points.AddXY(comboBox3.Text, comboBox6.Text); 
        chart1.Series["yyy"].Points.AddXY(comboBox1.Text, comboBox4.Text); 
    } 
