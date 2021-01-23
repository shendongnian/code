     Steema.TeeChart.Styles.ColorGrid colorgrid1;
            private void InitializeChart()
            {
                tChart1.Aspect.View3D = false;
                colorgrid1 = new ColorGrid(tChart1.Chart);
                colorgrid1.FillSampleValues();
                colorgrid1.CenteredPoints = true;
                
            }
