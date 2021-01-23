     private void InitializeChart()
            {
                tChart1.Series.Clear();
                Steema.TeeChart.WPF.Styles.Line line1 = new Steema.TeeChart.WPF.Styles.Line(tChart1.Chart);
                Steema.TeeChart.WPF.Styles.Line line2 = new Steema.TeeChart.WPF.Styles.Line(tChart1.Chart);
                line2.FillSampleValues();
                line1.FillSampleValues();
    
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                for (int i = 0; i < 2; i++)
                {
                    Steema.TeeChart.WPF.Styles.Points s = new Steema.TeeChart.WPF.Styles.Points(tChart1.Chart);
                    s.DataSource = tChart1[i];
                    tChart1[i].Visible = false;
                }
    
            }
