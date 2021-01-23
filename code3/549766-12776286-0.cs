    public partial class Form1: Form
    {
        private readonly Task<Binarylist> bList = 
            Task.Factory.StartNew(() => new Binarylist());
    
        private Form1_Load(object sender, EventArgs e)
        {
            // Get the result of the task when needed
            var constructedList = bList.Result;
            // ...
        }
    }
