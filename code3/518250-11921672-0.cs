    private void button1_Click(object sender, EventArgs e)
        {
            var projectFileName = @"...\MyApplication\MyApplication.sln";   
           ProjectCollection pc = new ProjectCollection(); 
           var GlobalProperty = new Dictionary<string, string>(); 
           GlobalProperty.Add("Configuration", "Debug"); 
           GlobalProperty.Add("Platform", "x86");
           BuildManager.DefaultBuildManager.BeginBuild(new BuildParameters(pc));
           BuildRequestData request = new BuildRequestData(projectFileName, GlobalProperty, null, new string[] { "Build" }, null); 
           BuildSubmission submission = BuildManager.DefaultBuildManager.PendBuildRequest(request); 
            submission.ExecuteAsync(null, null);
            int cpt = 0;
            while (!submission.IsCompleted)
            {
                cpt++;
                textBox1.Text = cpt.ToString();
            }
            
            
            BuildManager.DefaultBuildManager.EndBuild();   
            // If the build failed, return an error string.    
            if (submission.BuildResult.OverallResult == BuildResultCode.Failure)      
            {                 //do some error task           
            } 
        }
       
