        class LabelOrTextBoxTypeConverter : ControlIDConverter
        {
        //public ControlByTypeIDConverter(List<Type> WantedControlTypes)
        //{
        //    this.ControlTypes = WantedControlTypes;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        protected override bool FilterControl(Control control)
        {
            bool isWanted = false;
            foreach (var atype in this.ControlTypes)
            {
                isWanted |= control.GetType() == atype;
            }
            return isWanted;
        }
        public List<Type> ControlTypes { get { return new List<Type>() { typeof(TextBox), typeof(Label) }; } }
    }
