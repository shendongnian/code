     protected void Page_Load(object sender, EventArgs e)
     {
          DataTable dt = default(DataTable);
          dt = MyChartDataSource(); //datasource for your chart
    
         //Give two columns of data to Y-axle
          Chart1.Series[0].YValueMembers = "Volume1";
          Chart1.Series[1].YValueMembers = "Volume2";
    
           //Set the X-axle as date value
           Chart1.Series[0].XValueMember = "Date";
                
           //Bind the Chart control with the setting above
           Chart1.DataSource = dt;
           Chart1.DataBind();
             
           //after databinding your chart, override the colors of bar as below:
           Random random = new Random(); 
           foreach (var item in Chart1.Series[0].Points)
           {
              Color c = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
              item.Color = c;
            }
     }
