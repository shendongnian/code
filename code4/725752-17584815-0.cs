         StackPanel sp=new StackPanel();
        foreach(Model.questionhint qhm in lstQuestionHints)
        {
	    StackPanel sp1=new StackPanel(){Orientation=Orientation.Horizontal};	 
            TextBlock tb = new TextBlock();
            tb.Text = qhm.QuestionContent;              
            tb.FontWeight = FontWeights.Bold;
            tb.FontSize = 24;
            sp1.Children.Add(lbl);
            if (qhm.Option1.Trim().Length > 0 &&
                qhm.Option2.Trim().Length > 0)
            {
                ComboBox cb = new ComboBox();
                cb.Items.Add(qhm.Option1);
                cb.Items.Add(qhm.Option2);
                cb.Width = 200;
                sp1.Children.Add(cb);
            }
           sp.Children.Add(sp1); 
        }
        WrapPanelTest.Children.Add(sp);
