    AjaxControlToolkit.CalendarExtender calenderDate = new AjaxControlToolkit.CalendarExtender();
    
                for (int i = 0; i < 2; i++)
                {
                    Label label = new Label();
                    TextBox text = new TextBox();
                    label.Text = Convert.ToString("varName");
                    ph1.Controls.Add(label);
    
                    text.ID = "myId" + i;
    
                    ph1.Controls.Add(new LiteralControl("&nbsp;"));
    
                    ph1.Controls.Add(text);
    
    
                    calenderDate.TargetControlID = text.ID;
                    ph1.Controls.Add(calenderDate);
    
    
                    ph1.Controls.Add(new LiteralControl("<br />"));
                }
