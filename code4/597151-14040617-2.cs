            var OptionsPropertyGrid = new PropertyGrid();
            OptionsPropertyGrid.Size = new Size(300, 250);
            this.Controls.Add(OptionsPropertyGrid);
            this.Text = "Options Dialog";
            string classname = "WindowsFormsApplication1.TestPropertyObject";
            var type1 = Type.GetType(classname);
            object obj = Activator.CreateInstance(type1);
            OptionsPropertyGrid.SelectedObject = obj;
