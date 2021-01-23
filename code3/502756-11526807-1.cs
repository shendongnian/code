        protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var q = e.Item.DataItem as Question;
            if (q == null)
                throw new InvalidOperationException();
            var panel = e.Item.FindControl("panel");
            if (q.MultipleAnswers)
            {
                var checks = new CheckBoxList { DataSource = q.Answers, DataTextField = "AnswerText", DataValueField = "ID" };
                checks.DataBind();
                panel.Controls.Add(checks);
            }
            else
            {
                var radios = new RadioButtonList { DataSource = q.Answers, DataTextField = "AnswerText", DataValueField = "ID" };
                radios.DataBind();
                panel.Controls.Add(radios);
            }
        }
