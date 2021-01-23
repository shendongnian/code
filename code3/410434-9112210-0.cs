            tChart1.Legend.CheckBoxes = true;
            for (int i = 0; i < 5; i++)
            {
                new Steema.TeeChart.Styles.Gantt(tChart1.Chart);
                tChart1[i].FillSampleValues();    
            }
            tChart1.Page.MaxPointsPerPage = 2;
            tChart1.Page.Next();
