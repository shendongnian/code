     private void button1_Click(object sender, EventArgs e)
                {
        listbox1.items.add("Operating System Detaiils");
         OperatingSystem os = Environment.OSVersion;
    listbox1.items.add("OS Version: " + os.Version.ToString());
        // and so on...
        
        }
