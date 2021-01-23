    public class MyFancyForm {
        private Dictionary<string, Bitmap> lookup;
        private void Form1_Load(object sender, System.EventArgs e) {
            // init dictionary
            lookup = new Dictionary<string, Bitmap>() {
                {"0", new Bitmap(@"C:\0money\0.bmp", true)},
                {"1", new Bitmap(@"C:\0money\1.bmp", true)}
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            // do something with lookup
        }
    }
