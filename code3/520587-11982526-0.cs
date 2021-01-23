    private async void EnumerateWebcamsAsync()
        {
            try
            {
                ShowStatusMessage("Enumerating Webcams...");
                m_devInfoCollection = null;
                EnumedDeviceList2.Items.Clear();
                m_devInfoCollection = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
                if (m_devInfoCollection.Count == 0)
                {
                    ShowStatusMessage("No WebCams found.");
                }
                else
                {
                    for (int i = 0; i < m_devInfoCollection.Count; i++)
                    {
                        var devInfo = m_devInfoCollection[i];
                        EnumedDeviceList2.Items.Add(devInfo.Name);
                    }
                    EnumedDeviceList2.SelectedIndex = 0;
                    ShowStatusMessage("Enumerating Webcams completed successfully.");
                    btnStartDevice2.IsEnabled = true;
                }
            }
            catch (Exception e)
            {
                ShowExceptionMessage(e);
            }
        }
