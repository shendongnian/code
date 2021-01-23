     PieSeries pie1 = new PieSeries();
     pie1.IndependentValueBinding = new Binding("food");
                                    pie1.DependentValueBinding=new Binding("renterInsurance");
                                    pie1.ItemsSource = tempData;
                                    chart1.Series.Add(pie1);
     pie1.ItemsSource = List<YourClass>;
