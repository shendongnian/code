    private static void CheckForUpdate() {
                try {
                    ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;
                    UpdateCheckInfo info = updateCheck.CheckForDetailedUpdate();
                    if(info.UpdateAvailable) {
                        updateCheck.Update();
                        WasUpdated = true;
                        MessageBox.Show( "The application has been upgraded, and will now restart." );
                    }
                } catch(DeploymentDownloadException ex) {
                    MessageBox.Show( "Automatic Update Failed.  Error: " + ex );
                } catch(InvalidDeploymentException ex) {
                    MessageBox.Show( "Automatic Update Failed.  Error: " + ex );
                } catch(DeploymentException ex) {
                    MessageBox.Show( "Automatic Update Failed.  Error: " + ex );
                } catch(Exception ex) {
                    MessageBox.Show( "Automatic Update Failed.  Error: " + ex );
                }
            }
