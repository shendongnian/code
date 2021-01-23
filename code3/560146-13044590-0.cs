    public partial class Main
    {
        public void function1()
        {
            doing_stuff_here();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var update = new UpdateDialog();
            update.OnButton2Click += OnUpdateDialogButton2Click;
            update.ShowDialog();
        }
        void OnUpdateDialogButton2Click(object sender, EventArgs e)
        {
            function1();
        }
    }
    public partial class UpdateDialog
    {
        public event EventHandler<EventArgs> OnButton2Click;
        private void button2_Click(object sender, EventArgs e)
        {
            //call here function1() from Main  
            if (OnButton2Click != null)
            {
                this.OnButton2Click(this, e);
            }
        }
    }
