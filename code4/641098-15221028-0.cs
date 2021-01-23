        [NotMapped]
        public double[] Data
        {
            get
            {
                string[] tab = this.InternalData.Split(',');
                return new double[] { double.Parse(tab[0]), double.Parse(tab[1]) };
            }
            set
            {
                this.InternalData = string.Format("{0},{1}", value[0], value[1]);
            }
        }
        public string InternalData { get; set; }
