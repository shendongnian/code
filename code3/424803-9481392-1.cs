        private void checkAnswer(object sender, System.EventArgs e)
        {
            var cssClass = sender.GetType().GetProperty("CssClass");
            var id = sender.GetType().GetProperty("ID").GetValue(sender, null);
            for (int i = 0; i < _numberWords; i++)
            {
                if (id!=null)
                {
                    if (id.ToString() == "answer" + i.ToString())
                    {
                        cssClass.SetValue(sender, "textbuttonRight", null);
                    }
                    else
                    {
                        cssClass.SetValue(sender, "textbuttonRight", null);
                    }
                }
            }
        }
