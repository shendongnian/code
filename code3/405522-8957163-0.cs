        if (!ary.Contains(headingText))
        {
            ary.Add(headingText);
            Session["reportQuestionGroupingTracker"] = ary;
        }
        lit.Text = String.Format(@"<h3 class=""questionGroupingHeader"">{0}</h3>", headingText);
        lit.Visible = true;
 
