        private void AssignClickEvent()
        {
            foreach (Control c in tableLayout.Controls.OfType<Label>())
            {
                c.MouseClick += tablelayout_MouseClick;
                addDevice.Click += addDevice_Click;
                deleteDevice.Click += deleteDevice_Click;
                fire.Click += fire_Click;
                fault.Click += fault_Click;
                suppress.Click += suppress_Click;
                
            }
        }
