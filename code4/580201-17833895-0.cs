    private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation.Equals(ScrollOrientation.HorizontalScroll))
            {
                checkBox1.Location = new Point(checkBox1.Location.X - (e.NewValue - e.OldValue), checkBox1.Location.Y);
            }
            if (checkBox1.Location.X < dataGridView1.Location.X + 40)
            {
                checkBox1.Visible = false;
            }
            else
            {
                checkBox1.Visible = true;
            }
        }
