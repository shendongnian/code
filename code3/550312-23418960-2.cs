      #region check and download new version program
      bool bSuccess = false;
      IAutoUpdater autoUpdater = new AutoUpdater();
      try
      {
          autoUpdater.Update();
          bSuccess = true;
      }
      catch (WebException exp)
      {
          MessageBox.Show("Can not find the specified resource");
      }
      catch (XmlException exp)
      {
          MessageBox.Show("Download the upgrade file error");
      }
      catch (NotSupportedException exp)
      {
          MessageBox.Show("Upgrade address configuration error");
      }
      catch (ArgumentException exp)
      {
          MessageBox.Show("Download the upgrade file error");
      }
      catch (Exception exp)
      {
          MessageBox.Show("An error occurred during the upgrade process");
      }
      finally
      {
          if (bSuccess == false)
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
