    public class MySecondClass {
    
        private MainForm mainForm;
    
        public MySecondClass(MainForm mainForm) 
        {
            this.mainForm = mainForm; 
        }
    
        public void SomeFinctionOfNewClass()
        {
            this.mainForm.Label10.Text = "Some text for label"; // it's using property
        }
    }
