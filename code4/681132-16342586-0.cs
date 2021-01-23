    public class A
    {       
        B obj1 = new B();
        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            obj1.PageChanged(tabControl1.SelectedIndex.ToString());
        }
    }
    public partial class B 
    {       
        public void PageChanged(string Val)
        {
            //put your code 
            // after page chaged what should happen
        }
    }
