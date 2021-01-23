     protected void Page_Load(object sender, EventArgs e)
        {
          if(!Page.IsPostBack)  // Teis is the key line for avoiding the problem
          {
            Levels loadGame = new Levels(currentGame);
            int [] gameNums =  loadGame.getLevelNums();
            int inc = 1;
            foreach(int i in gameNums){
                if (i != 0)
                {
                    TextBox tb = (TextBox)FindControl("TextBox" + inc);
                    tb.Text = i.ToString();
                    tb.Enabled = false;
                }
                else {
                    //leave blank and move to next box
                }
                inc++;
            }
          }
         }
