    // Your UserControl.
    class StripButton : Label
    {
        protected override void OnClick(EventArgs e) {
            Console.WriteLine("This runs before the Click handler on the parent form.");
            base.OnClick(e);
            Console.WriteLine("This runs after the Click handler on the parent form.");
        }
    }
    
    // On your form.
    private void stripButton1_Click(object sender, EventArgs e) {
        Console.WriteLine("stripButton1_Click on form");
    }
