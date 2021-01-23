    Barcode barcode = new Barcode();
            pic = new PictureBox();
            pic.Name = "bCode" + bNum;
            pic.SizeMode = PictureBoxSizeMode.AutoSize;
            pic.Image = barcode.createBarcode(BarcodeLib.TYPE.CODE128, 300, 100, "123456789");
            
            pic.Show();
            labelHolder.Controls.Add(pic);
            pic.BringToFront();
            pic.MouseDown += pic_MouseDown;
            pic.MouseMove +=pic_MouseMove;
            pic.MouseUp += pic_MouseUp;
        }
        PictureBox thisPB;
         private void pic_MouseDown(object sender, MouseEventArgs e)
        {             
            mouseDown = true;
            
            oldX = e.X;
            oldY = e.Y;           
        }
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {             
                    thisPB = (PictureBox)sender;
                    thisPB.Location = new Point(thisPB.Location.X - (oldX - e.X), thisPB.Location.Y - (oldY - e.Y));
                   
                    this.Refresh();                
            }            
        }
        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;           
        }
