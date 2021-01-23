    public class GameForm : Form
    {
        public GameForm()
        {
            this.KeyDown += Game_KeyDown;
            var tests = new List<Control[]>() { 
                new[] { new Panel() },
                new[] { new Panel(), new Panel() },
                new[] { new Control() },
                new[] { new Control(), new Panel() },
                new[] { new Panel(), new Control() }
            };
            // When test index 2 to 4 used, keyboard input does not reach form level
            Controls.AddRange(tests[0]);            
            // When uncommented, ensures all keyboard input reaches form level
            /*this.KeyPreview = true;              
            // Additional plumbing required along with KeyPreview to allow arrow and other reserved keys
            foreach (Control control in this.Controls)
            {
                control.PreviewKeyDown += control_PreviewKeyDown;
            }*/
        }
        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            // breakpoint here
            Debug.WriteLine(e.KeyCode);
        }
    }
