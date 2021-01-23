                WaveChannel32 wave = new WaveChannel32(new WaveFileReader(txtWave.Text));
                int sampleSize = 1024;
                var bufferSize = 16384 * sampleSize;
                var buffer = new byte[bufferSize];
                int read = 0;
                chart.Series.Add("wave");
                chart.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart.Series["wave"].ChartArea = "ChartArea1";
                while (wave.Position < wave.Length)
                {
                    read = wave.Read(buffer, 0, bufferSize);
                    for (int i = 0; i < read / sampleSize; i++)
                    {
                        var point = BitConverter.ToSingle(buffer, i * sampleSize);
                        
                        chart.Series["wave"].Points.Add(point);
                    }
                }
