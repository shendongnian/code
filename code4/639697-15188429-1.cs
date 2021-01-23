            int w = 100, z = 100; // Initial position
            this.click++; // Click value increase everytime you click
            ComboBox c;  
            this.Controls.Add(c = new ComboBox() // Create new combobox
            {
                Location = new Point(w, z + (click * 30)), // Each time you click, position on x-axis will stay and y-axis will increase by `click` multiply by 30 (you can change this '30' value)
                Width = 121,
                Height = 21,
            });
            for (int i = 0; i < elements.Length; i++) // Loop 7 times
            {
                c.Items.Add(this.elements[i]);
            }
