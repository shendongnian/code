        private bool InternetIsAvailable()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                //MessageBox.Show("No tienes conexión de internet.");
                return false;
            }
            else
            {
                //MessageBox.Show("Tienes conexión de internet.");
                return true;
            }
        }
