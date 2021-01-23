        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            var img = pictureBox1.Image;
            if (img == null) return;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move) {
                pictureBox1.Image = null;
            }
        }
