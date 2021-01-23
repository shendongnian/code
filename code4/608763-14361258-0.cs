    // Create a resource manager to retrieve resources.
    ResourceManager rm = new ResourceManager("items", Assembly.GetExecutingAssembly());
    
    // Retrieve the value of the string resource named "filepath".
    // The resource manager will retrieve the value of the  
    // localized resource using the caller's current culture setting.
    
    public void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                // in the filepath variable we are going to put the path file that we browsed.
                filepath = txtPath.Text;
                if (filepath == string.Empty)
                {
                    String str = rm.GetString("welcome");
                    MessageBox.Show(str);
                }
           }
