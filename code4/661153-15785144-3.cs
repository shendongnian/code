    orgMeasConSettings.DeviceDefinitionList.Clear();
				foreach (DeviceDefinition deviceDefinition in newSettings.DeviceDefinitionList)
				{
					orgMeasConSettings.DeviceDefinitionList.Add(deviceDefinition);
				}
				orgMeasConSettings.SelectedDeviceDefinition = newSettings.DeviceDefinitionList.FirstOrDefault();
