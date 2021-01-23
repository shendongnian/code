      #region check and download new version program
      bool bHasError = false;
      IAutoUpdater autoUpdater = new AutoUpdater();
      try
      {
          autoUpdater.Update();
      }
      catch (WebException exp)
      {
          MessageBox.Show("Can not find the specified resource");
          bHasError = true;
      }
      catch (XmlException exp)
      {
          bHasError = true;
          MessageBox.Show("Download the upgrade file error");
      }
      catch (NotSupportedException exp)
      {
          bHasError = true;
          MessageBox.Show("Upgrade address configuration error");
      }
      catch (ArgumentException exp)
      {
          bHasError = true;
          MessageBox.Show("Download the upgrade file error");
      }
      catch (Exception exp)
      {
          bHasError = true;
          MessageBox.Show("An error occurred during the upgrade process");
      }
      finally
      {
          if (bHasError == true)
          {
              try
              {
                  autoUpdater.RollBack();
              }
              catch (Exception)
              {
                 //Log the message to your file or database
              }
          }
      }
      #endregion
