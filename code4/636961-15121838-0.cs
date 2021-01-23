        public int Num {
            set {
                this.Text = value.ToString();
            }
            get {
                return Int16.Parse(this.Text);
            }
        }
