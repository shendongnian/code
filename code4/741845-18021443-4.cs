    public partial class _Default : Page
    {
        Control containerDiv;
        protected void Page_Load(object sender, EventArgs e)
        {
             this.containerDiv = SomeMethodThatCreatesADiv();
             this.Page.Controls.Add(containerDiv);
        }
        void SomeOtherMethod()
        {
            this.containerDiv.Controls.Add(
                new LinkButton()
                {
                    ID = GetNewID(),
                    CommandName = "DoSomething",
                    CommandArgument = "arg",
                    Text= "Try Me",
                });
        }    
    }
