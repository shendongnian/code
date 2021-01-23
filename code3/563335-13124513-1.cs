    public class CustomTabPage : TabPage
    {
        public CustomTabPage()
        {
            //create your Controls and setup their properties
            Button btn1 = new Button();
            btn1.Location = new Point(20, 20);
            btn1.Size = new System.Drawing.Size(40, 20);
            //add controls to the CustomTabPage
            this.Controls.Add(btn1);
        }
    }
    //Create CustomTabPage
    CustomTabPage ctp = new CustomTabPage();
    tabControl1.TabPages.Add(ctp);
