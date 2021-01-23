        public void ShowMessage(string message)
        {
            Component.InstanceOfTopMost.TopMost = false;
            MessageBox.Show(message);
            Component.InstanceOfTopMost.TopMost = true;
        }
