        public class FormA : Form
        {
            private void myUpdateDelegate(object sender, EventArgs e)
            {
                // Do your updates that formA will require here
            }
            public void methodCallingFormB()
            {
                // Do whatever you need to set up for creating form B
                var formB = new FormB();
                formB.UpdateEvent += myUpdateDelegate;
                formB.Show();
            }
        }
