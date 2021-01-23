        private readonly List<ComboBox> combosToSetIndexOn = new List<ComboBox>();
        private bool firstActivation = true;
        private Control firstWindowsControl = null;
        ...
        // Other ciode sets firstWindowsControl...
        private void DynamicForm_Activated(object sender, EventArgs e)
        {
            if (firstActivation)
            {
                firstActivation = false;
                bool fwcPresent = (firstWindowsControl != null);
                Console.WriteLine($"DynamicForm_Activated: firstWindowControl present: {fwcPresent}");
                if (fwcPresent)
                {
                    firstWindowsControl.Focus();
                }
  
                if (combosToSetIndexOn.Count > 0)
                {
                    foreach (ComboBox c in combosToSetIndexOn)
                    {
                        Console.WriteLine($"DynamicForm_Activated: processing: {c.Name}");
                        c.SelectedIndex = 0;
                    }
                }
            }
