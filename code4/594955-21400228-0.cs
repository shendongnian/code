        private static String getDeviceId()
            {
                byte[] id = (byte[])Microsoft.Phone.Info.DeviceExtendedProperties.GetValue("DeviceUniqueId");
                return BitConverter.ToString(id).Replace("-", string.Empty);
            }
