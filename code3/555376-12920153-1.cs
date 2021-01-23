    private void CheckApplicationStatus() {
        if (ApplicationDeployment.IsNetworkDeployed) {
            // Do something that needs doing when the application is installed using ClickOnce.
        } else {
            // Do something that needs doing when the application is run from VS.
        }
    }
