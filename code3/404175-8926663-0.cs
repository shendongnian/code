            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Load Image";
                if (ofd.ShowDialog() == DialogResult.OK) {
                    var box = new Form();
                    box.TopLevel = box.ControlBox = false;
                    box.Visible = true;
                    box.BackgroundImage = new Bitmap(ofd.FileName);
                    panelArea.Controls.Add(box);
                    box.Size = box.BackgroundImage.Size;
                }
            }
