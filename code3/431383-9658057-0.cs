            // Got group box control
            Control[] controls = Controls.Find("groupBox1", false);
            // List all elements in group box
            foreach(var c in ((Control)controls[0]).Controls)
            {
                // Update in case it is label
                if( c.GetType().ToString().EndsWith("Label") )
                {
                    ((Label)c).Text = "label...";
                }
            }
