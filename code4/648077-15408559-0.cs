        public IEnumerable<Button> Buttons
        {
            get
            {
                List<Button> buttons = new List<Button>();
                foreach (Control ctrl in ParentForm.Controls)
                {
                    Button btn = ctrl as Button;
                    if (btn != null)
                    {
                        buttons.Add(btn);
                    }
                }
                return buttons;
            }
        }
