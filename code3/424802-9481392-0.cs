        private void checkAnswer(object sender, System.EventArgs e)
        {
            var cssClass = sender.GetType().GetProperty("CssClass");
            var id = sender.GetType().GetProperty("ID").GetValue(sender, null).ToString();
            for (int i = 0; i < _numberWords; i++)
            {
                if (!String.IsNullOrEmpty(id))
                {
                    if (id == "answer" + i.ToString())
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
