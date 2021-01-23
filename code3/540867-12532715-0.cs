     private void AddControls(int controlNumber)
        {
          
            var newPanel = new Panel();
            var natureLabel = new Label();
            var dateLabel = new Label();
            var fatalLabel = new Label();
            var injurLabel = new Label();
            var natureTextbox = new TextBox();
            var dateTextbox = new TextBox();
            var fatalTextbox = new TextBox();
            var injurTextbox = new TextBox();
            // textbox needs a unique id to maintain state information
            natureTextbox.ID = "NatureTextBox_" + controlNumber;
            dateTextbox.ID = "DateTextbox_" + controlNumber;
            fatalTextbox.ID = "fatalTextbox_" + controlNumber;
            injurTextbox.ID = "injurTextbox_" + controlNumber;
            natureLabel.Text = "Nature Of Accident: ";
            dateLabel.Text = "Date: ";
            fatalLabel.Text = "Fatalities: ";
            injurLabel.Text = "Injuries: ";
            // add the label and textbox to the panel, then add the panel to the form
            newPanel.Controls.Add(new LiteralControl("<table><tr>"));
            newPanel.Controls.Add(new LiteralControl("<br />"));
            newPanel.Controls.Add(new LiteralControl("<td class='title-text'  >"));
            newPanel.Controls.Add(natureLabel);
            newPanel.Controls.Add(new LiteralControl("</td><td class='title-text'width='180px'>"));
            newPanel.Controls.Add(natureTextbox);
            newPanel.Controls.Add(new LiteralControl("</td><td class='title-text' >"));
            newPanel.Controls.Add(dateLabel);
            newPanel.Controls.Add(new LiteralControl("</td><td class='title-text'>"));
            newPanel.Controls.Add(dateTextbox);
            newPanel.Controls.Add(new LiteralControl("</td></tr>"));
            newPanel.Controls.Add(new LiteralControl("<tr><td class='title-text'>"));
            newPanel.Controls.Add(fatalLabel);
            newPanel.Controls.Add(new LiteralControl("</td><td class='title-text'>"));
            newPanel.Controls.Add(fatalTextbox);
            newPanel.Controls.Add(new LiteralControl("</td><td class='title-text'>"));
            newPanel.Controls.Add(injurLabel);
            newPanel.Controls.Add(new LiteralControl("</td><td class='title-text'>"));
            newPanel.Controls.Add(injurTextbox);
            newPanel.Controls.Add(new LiteralControl("</td></tr></table>"));
            form1.Controls.Add(newPanel);
        }
        protected int TotalNumberAdded
        {
            get { return (int)(ViewState["TotalNumberAdded"] ?? 0); }
            set { ViewState["TotalNumberAdded"] = value; }
        }
