    namespace Bonitas.SalesRepQuiz
    {
       public partial class QuizBackend : PortalModuleBase
       {
            protected override void OnInit(EventArgs e)
            {
                base.OnInit(e);
                btnYourButton.Click += btnYourButton_Click;
            }
            
            protected void btnYourButton_Click(object sender, EventArgs e)
            {
                try
                {
                    // Your code
                }
                catch (Exception ex)
                {
                    Exceptions.ProcessModuleLoadException(this, ex);
                }
            }
        }
    }
