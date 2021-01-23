    using System.Deployment.Application;
    public Version AssemblyVersion 
    {
        get
        {
            return ApplicationDeployment.CurrentDeployment.CurrentVersion;
        }
    }
	YourVersionTextBox.Text = AssemblyVersion.ToString(1); // 1 - get only major
	YourVersionTextBox.Text = AssemblyVersion.ToString(2); // 1.0 - get only major, minor
	YourVersionTextBox.Text = AssemblyVersion.ToString(3); // 1.0.3 - get only major, minor, build
	YourVersionTextBox.Text = AssemblyVersion.ToString(4); // 1.0.3.4 - get only major, minor, build, revision
