        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            TextBox textBox1 = sender as TextBox;
            Point newPoint = new Point(e.X, e.Y);
            newPoint = textBox1.PointToClient(newPoint);
            int index = textBox1.GetCharIndexFromPosition(newPoint);
            object item = listBox1.Items[listBox1.IndexFromPoint(p)];
            if (textBox1.Text == "")
            {
                textBox1.Text = item.ToString();
            }
            else
            {
                var text = textBox1.Text;
                var lastCharPosition = textBox1.GetPositionFromCharIndex(index);
                if (lastCharPosition.X < newPoint.X)
                {
                    text += item.ToString();
                }
                else
                {
                    text = text.Insert(index, item.ToString());
                }
                textBox1.Text = text;
            }
            listBox1.Items.Remove(item);
        }
