        private void SetControlValueToEmpty()
        {
            IEnumerable<HtmlInputControl> htmlInputControls = form1.Controls.OfType<System.Web.UI.HtmlControls.HtmlInputControl>();
            foreach (var htmlInputControl in htmlInputControls)
            {
                if (htmlInputControl.Attributes["title"] == htmlInputControl.Value)
                {
                    htmlInputControl.Value = "";
                }
            }
        }
