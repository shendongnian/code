        public class Process
        {
            public Page thePage { get; set; }
            public Process(Page page)
            {
                thePage = page;
            }
            public string GetTextBoxValue()
            {
                TextBox tb = (TextBox)thePage.FindControl("txtTest");
                return tb.Text;
            }
        }
