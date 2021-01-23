     ...
     this.trcResults.DataBinding += this.trcResults_DataBinding;
     this.trcResults.BeforeLayout += this.trcResults_BeforeLayout;
     this.trcResults.DataSource = pcl;
     this.trcResults.DataBind();
    }
     
    void trcResults_DataBinding(object sender, EventArgs e)
    {
     var senderChart = (RadChart)sender;
     var pcl = senderChart.DataSource as IEnumerable<PollContainer>;
     
     foreach (var pollContainer in pcl)
     {
      // prepend a sentinel symbol
      pollContainer.AnswerText = "x" + pollContainer.AnswerText;
     }
    }
     
     
    void trcResults_BeforeLayout(object sender, EventArgs e)
    {
     foreach (var axisItem in this.trcResults.PlotArea.XAxis.Items)
     {
      // remove the sentinel symbol
      axisItem.TextBlock.Text = axisItem.TextBlock.Text.Remove(0, 1);
     }
    }
