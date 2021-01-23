    private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Point MyPoint = new Point(100, 200);
            DoDragDrop(new string[] { MyPoint.X.ToString(), MyPoint.Y.ToString() }, DragDropEffects.Copy);
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string[])))
            {
                string[] item = (string[])e.Data.GetData(typeof(string[]));
                Point e2 = new Point(Int32.Parse(item[0]), Int32.Parse(item[1]));
                MessageBox.Show(e2.X+":"+e2.Y);
            }
        
        }
