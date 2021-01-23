    public  class TestColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.Red; }
        }
        public override Color MenuBorder  //added for changing the menu border
        {
            get { return Color.Green; }
        }
    }
