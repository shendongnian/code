     static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                // Construct a MenuStrip with one item "Menu" with one dropdown-item "Popup"
                var mainMenu = new MenuStrip();
                var mainItem = new ToolStripMenuItem("Menu");
                mainItem.DropDownItems.Add(new ToolStripMenuItem("Popup", null, Popup));
                mainMenu.Items.Add(mainItem);
    
                // Create form with MenuStrip and Show
                var form1 = new Form();
                form1.Controls.Add(mainMenu);
                Application.Run(form1);
            }
    
            private static void Popup(object sender, EventArgs e)
            {
                // Create a form with a right click handler and show
                var form2 = new Form();
                var contextMenu = new ContextMenuStrip();
                contextMenu.Items.Add("Just an item...");
                var loc = form2.Location; //<---- get the location
                var p2 = new Point(loc.X, loc.Y); //<---- get the point of form
                form2.ContextMenuStrip = contextMenu;
                form2.ContextMenuStrip.Show(form2, p2); //<---- just add this code.
                form2.Show();
                // Problem: contextMenu.Show() will give focus to form1
            }
        }
