     try
            {
                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.Visible = true;
                //CODES HERE TO GET THE SELECTED PAGE FROM DROP DOWN LIST
                var fb = new FacebookClient(myToken.Default.token);
                var query = string.Format("SELECT metric, value FROM insights WHERE object_id=132414626916208 AND metric='page_fans_gender_age' AND period = period('lifetime') AND end_time = end_time_date('2013-01-18')");
                dynamic parameters = new ExpandoObject();
                parameters.q = query;
                var data = fb.Get<genderAgeDataII>("fql", parameters);
                genderAge yf = (genderAge)data.data[0].value;
                //females age range
                string[,] gAge = new string[10, 2];
                gAge[0, 0] = "F.13-17";
                gAge[0, 1] = yf.f1317.ToString();
                gAge[1, 0] = "F.18-24";
                gAge[1, 1] = yf.f1824.ToString();
                gAge[2, 0] = "M.25-34";
                gAge[2, 1] = yf.m2534.ToString();
                gAge[3, 0] = "M.13-17";
                gAge[3, 1] = yf.m1317.ToString();
                gAge[4, 0] = "M.18-24";
                gAge[4, 1] = yf.m1824.ToString();
                for (int i = 0; i < gAge.GetLength(0); i++)
                {
                    if (gAge[i, 0] == null)
                    {
                        break;
                    }
                    else
                    {
                        
                       string[] seriesArray = { gAge[i,0] };
                       // Add series.
                       for (int w = 0; w < seriesArray.Length; w++)
                       {
                           // Add series.
                           Series series = this.chart1.Series.Add(seriesArray[w]);
                           int[] pointsArray = new int[seriesArray.Length];
                           pointsArray[w] = Convert.ToInt32(gAge[i, 1]);
                           series.Points.Add(pointsArray[w]);
                       }
                       
                       Console.WriteLine(gAge[i, 0].ToString());
                    }
                    
                }
