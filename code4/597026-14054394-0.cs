        /// <summary>
        /// Converst the list of byte arrays which contains the 
        /// protocol paramters into a single byte array
        /// </summary>
        private void VectorizeProtParList()
        {
            if (listofArrays != null && listofArrays.Count > 0)
            {
                var flattenedList =
                    listofArrays.SelectMany(bytes => bytes);
                savedPPDataArray = flattenedList.ToArray();
                MessageBox.Show("New Protocol parameter data saved", "Save Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("PP Data list seems to have no data", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
