        private List<Button> buttonList = new List<Button>();
        private void addButtonsDynamically(object sender, EventArgs e)
        {
            int top = 10, left = 10;
            for (int i = 1; i <= 16; i++)
            {
                Button btn = new Button();
                btn.Parent = this;
                btn.Size = new Size(25, 25);
                btn.Text = (i - 1).ToString();
                btn.Location = new Point(left, top);
                left += 35;
                if (i > 0 && i % 4 == 0)
                {
                    top += 35;
                    left = 10;
                }
            }
        }
