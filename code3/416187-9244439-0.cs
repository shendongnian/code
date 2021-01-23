    public partial class _Default : System.Web.UI.Page
    {
        private SecretNumber guessNr;
    
        protected void Page_Load(object sender, EventArgs e) {
            this.guessNr = new SecretNumber();
        }
    
        protected void btnCheckNr_Click(object sender, EventArgs e) {
            if (!Page.IsValid) {
                return;
            }
    
            else {
                var guessedNr = int.Parse(inputBox.Text);
                var result = this.guessNr.MakeGuess(guessedNr);
                // Now use result
            }
        }
    }
