            List<Microsoft.VisualBasic.PowerPacks.OvalShape> ovalShape = new List<Microsoft.VisualBasic.PowerPacks.OvalShape>();
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    OvalShape ovl = new OvalShape();
                    ovl.Width = 20;
                    ovl.Height = 20;
                    ovl.FillStyle = FillStyle.Solid;
                    ovl.FillColor = Color.Green;
                    ovl.Location = new Point(ovl.Width*i, ovl.Height*j);
                    ovalShape.Add(ovl);
                }
            }
            foreach(OvalShape os in ovalShape)
            {
                  Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
                  Control c = new Control();
                  shapeContainer.Parent = c;
                  os.Parent = shapeContainer;
                  myForm.Controls.Add(c);              
            }
