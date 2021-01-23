    private void button1_Click(object sender, EventArgs e)
    {
        Microsoft.Win32.RegistryKey exampleRegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("ExampleTest");
        exampleRegistryKey.SetValue("Name", textBox1.Text);
        exampleRegistryKey.Close();
    }
