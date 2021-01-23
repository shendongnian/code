        public System.Windows.Forms.ComboBox.ObjectCollection Item
        {
            set {
                for (byte i = 0; i < value.Count; i++)
                    comboBox1.Items.Add(value[i].ToString());
            }
            get { return comboBox1.Items; }
        }
