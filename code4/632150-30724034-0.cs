      string sql3 = "SELECT COUNT(*) from systeminfo";//counting no of element
            n = dm.countelement(sql3);
            int i, c = 1;
            int m = 100;
            for (i = 0; i < n; i++, c++)
            {
                sql3 = " SELECT Company_name FROM systeminfo LIMIT " + (i + 1) + " OFFSET " + i + "";
                string cname = dm.getlang(sql3);
                
                PictureBox pb = new PictureBox();
                Label lb = new Label();
               pb.Location = new System.Drawing.Point(m, 30 + (30 * i));
               lb.Location = new System.Drawing.Point(m-30, 30 + ((30 * i)-30));
               pb.Name = "p" + c;
               lb.Name = "l" + c;
               lb.Size = new System.Drawing.Size(100, 20);
               pb.Size = new System.Drawing.Size(30, 30);
               lb.Text = cname;
               lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               lb.BackColor = Color.Transparent;
               pb.ImageLocation = @"..\image\image.jpg";
               pb.MouseDown += new         System.Windows.Forms.MouseEventHandler(this.picmap1_MouseDown_1);
               pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picmap1_MouseMove_1);
               pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picmap1_MouseUp_1);
                picmap1.Controls.Add(pb);
                picmap1.Controls.Add(lb);
                c++;
            }
