            var ovalShapes = new Microsoft.VisualBasic.PowerPacks.ShapeContainer()
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            for (int i = 0; i < 16; i++)
                for (int j = 0; j < 64; j++)
                    ovalShapes.Shapes.Add(
                        new Microsoft.VisualBasic.PowerPacks.OvalShape()
                        {
                            Width = 20,
                            Height = 20,
                            FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid,
                            FillColor = Color.Green,
                            Location = new Point(20 * i, 20 * j),
                        });
            this.Controls.Add(ovalShapes);
